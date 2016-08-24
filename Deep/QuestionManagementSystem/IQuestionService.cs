using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace Deep.QuestionManagementSystem
{
    [ServiceContract]
    interface IQuestionService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
                                    RequestFormat = WebMessageFormat.Json,
                                    ResponseFormat = WebMessageFormat.Json,
                                    UriTemplate = "projects/{p_id}/questions/add/")]
        bool addQuestionToProject(Question question, string p_id);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
                                    RequestFormat = WebMessageFormat.Json,
                                    ResponseFormat = WebMessageFormat.Json,
                                    UriTemplate = "projects/{p_id}/questions/{q_id}/variants/add")]
        bool addVariantToQuestion(Variant variant, string p_id, string q_id);

        [OperationContract]
        [WebInvoke(Method = "GET",
                            RequestFormat = WebMessageFormat.Json,
                            ResponseFormat = WebMessageFormat.Json,
                            UriTemplate = "projects/{p_id}/questions/")]
        List<QuestionWrapperWithVariants> getQuestions(string p_id);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    BodyStyle = WebMessageBodyStyle.Bare,
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "projects/{p_id}/surveys/{s_id}")]
        bool saveAnswers(List<Answer> answers, string p_id, string s_id);

        [OperationContract]
        [WebInvoke(Method = "GET",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "projects/{p_id}/answers/")]
        List<Answer> getAnswers(string p_id);
    }
}
