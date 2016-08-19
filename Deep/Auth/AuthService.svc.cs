using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Deep.Auth
{
   
    public class AuthService : IAuthService
    {
        DeepEntities context = new DeepEntities();

        public AuthBody Authorization(string username, string password, DateTime time)
        {
            AuthBody auth_body = new AuthBody();
            try
            {
                User user = context.Users.Where(p => p.username == username).Where(p => p.password == password).FirstOrDefault();
                if (user == null)
                {
                    auth_body.exception = "Incorrect username or password";
                    auth_body.access = false;
                    return auth_body;
                }
                else
                {
                    AccessToken token = context.AccessTokens.Where(p => p.id == user.id).FirstOrDefault();
                    if (token == null)
                    {
                        token = new AccessToken();
                        token.id = user.id;
                        token.access_token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                        token.refresh_token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                        token.last_refresh = DateTime.Now;

                        context.AccessTokens.Add(token);
                        context.SaveChanges();
                    }
                    else
                    {
                        token.access_token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                        token.refresh_token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                        token.last_refresh = DateTime.Now;

                        context.SaveChanges();
                    }
                    auth_body.access_token = token.access_token;
                    auth_body.refresh_token = token.refresh_token;
                    auth_body.exception = null;
                    
                    return auth_body;
                }
            }
            catch(Exception ex)
            {
                auth_body.access = false;
                auth_body.exception = ex.Message;
                return auth_body;
            }
        }

        public AuthBody Authentication(int user_id, string access_token)
        {
            AuthBody auth_body = new AuthBody();
            try
            {
                AccessToken token = context.AccessTokens.Where(p => p.id == user_id).Where(p => p.access_token == access_token).FirstOrDefault();
                if (token == null)
                {
                    auth_body.exception = "Access denied!";
                    auth_body.access = false;
                }
                else
                {
                    auth_body.exception = null;
                    auth_body.access = true;
                }
                return auth_body;
            }
            catch(Exception ex)
            {
                auth_body.access = false;
                auth_body.exception = ex.Message;
                return auth_body;
            }
        }

        public AuthBody UpdateToken(int user_id, string access_token, string refresh_token)
        {
            AuthBody auth_body = new AuthBody();
            try
            {
                AccessToken token = context.AccessTokens.Where(p => p.id == user_id).Where(p => p.access_token == access_token).Where(p => p.refresh_token == refresh_token).FirstOrDefault();
                if (token == null)
                {
                    auth_body.exception = "Some mistake";
                    auth_body.access_token = null;
                    auth_body.refresh_token = null;
                }
                else
                {
                    token.access_token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                    token.refresh_token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                    token.last_refresh = DateTime.Now;

                    context.SaveChanges();

                    auth_body.refresh_token = token.refresh_token;
                    auth_body.access_token = token.access_token;
                }
                return auth_body;
            }
            catch (Exception ex)
            {
                auth_body.exception = ex.Message;
                auth_body.access = false;
                return auth_body;
            }
        }
    }
}
