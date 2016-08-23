using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Deep.ProjectManagementSystem
{
    [DataContract]
    public class ProjectWrapper
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public int peopleCount { get; set; }
    }
}