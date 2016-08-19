using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Deep.Auth
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthService.svc or AuthService.svc.cs at the Solution Explorer and start debugging.
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
                        
                        
                    }
                    return auth_body;
                }
            }
            catch(Exception ex)
            {
                auth_body.exception = ex.Message;
                return auth_body;
            }
        }
    }
}
