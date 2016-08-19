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
    }
}
