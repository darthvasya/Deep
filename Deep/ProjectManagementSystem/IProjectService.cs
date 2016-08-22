using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Deep.ProjectManagementSystem
{
    [ServiceContract]
    interface IProjectService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
                                    RequestFormat = WebMessageFormat.Json,
                                    ResponseFormat = WebMessageFormat.Json,
                                    UriTemplate = "projects/add/")]
        bool addProject(Projects project);

        //name and count of people which is asked
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json,
                                   ResponseFormat = WebMessageFormat.Json,
                                   UriTemplate = "projects/")]
        List<ProjectWrapper> getProjectList();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json,
                                   ResponseFormat = WebMessageFormat.Json,
                                   UriTemplate = "projects/{id}")]
        Projects getProjectById(string id);




    }
}
