using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Deep.LoginSystem
{
    public class LoginService : ILoginService
    {
        DB_A0BEB4_deepEntities dbContext = new DB_A0BEB4_deepEntities();

        private Users getUserByUsername(String username)
        {
            return dbContext.Users.Where(p => p.username == username).First();
        }

        public bool login(Login login)
        {
            Users user = getUserByUsername(login.username);
            if ((user != null) && (user.password == login.password))
            {
                return true;
            }
            return false;
        }

        public bool register(Users user)
        {
            Users tempUser = getUserByUsername(user.username);
            if (tempUser == null)
            {
                dbContext.Users.Add(user);
                return true;
            }
            return false;            
        }
    }
}
