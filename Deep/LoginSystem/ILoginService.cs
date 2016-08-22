using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Deep.LoginSystem
{
    
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
                                    RequestFormat = WebMessageFormat.Json,
                                    ResponseFormat = WebMessageFormat.Json,
                                    UriTemplate = "register/")]
        bool register(Users user);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
                                    RequestFormat = WebMessageFormat.Json,
                                    ResponseFormat = WebMessageFormat.Json,
                                    UriTemplate = "login/")]
        bool login(Login login);

    }
}
