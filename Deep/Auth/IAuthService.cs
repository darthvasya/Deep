using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Deep.Auth
{
    
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        AuthBody Authorization(string username, string password, DateTime time);

        [OperationContract]
        AuthBody Authentication(int user_id, string access_token);

        [OperationContract]
        AuthBody UpdateToken(int user_id, string access_token, string refresh_token);
    }
}
