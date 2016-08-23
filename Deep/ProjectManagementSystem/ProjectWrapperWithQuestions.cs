using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Deep.QuestionManagementSystem;

namespace Deep.ProjectManagementSystem
{
    [DataContract]
    public class ProjectWrapperWithQuestions
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string description;

        [DataMember]
        public List<QuestionWrapperWithVariants> questionList;
    }
}