using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace Deep.LoginSystem
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LoginService : ILoginService
    {
        DB_A0BEB4_deepEntities dbContext = new DB_A0BEB4_deepEntities();

        private User getUserByUsername(string username)
        {
            return dbContext.User.Where(p => p.username == username).FirstOrDefault();
        }

        public bool login(Login login)
        {
            User user = getUserByUsername(login.username);
            if ((user != null) && (user.password == login.password))
            {
                return true;
            }
            return false;
        }

        public bool register(User user)
        {
            User tempUser = getUserByUsername(user.username);
            if (tempUser == null)
            {
                dbContext.User.Add(user);
                dbContext.SaveChanges();
                return true;
            }
            return false;            
        }
    }
}
