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
        bool addProject(Project project);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json,
                                   ResponseFormat = WebMessageFormat.Json,
                                   UriTemplate = "projects/")]
        List<ProjectWrapper> getProjectList();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json,
                                   ResponseFormat = WebMessageFormat.Json,
                                   UriTemplate = "projects/{id}/")]
        Project getProjectById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json,
                                   ResponseFormat = WebMessageFormat.Json,
                                   UriTemplate = "projects/{id}/questions/")]
        ProjectWrapperWithQuestions getProjectWithQuestionsById(string id);




    }
}
