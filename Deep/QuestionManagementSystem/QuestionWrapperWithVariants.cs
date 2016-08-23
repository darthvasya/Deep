using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Deep.QuestionManagementSystem
{
    [DataContract]
    public class QuestionWrapperWithVariants
    {
        [DataMember]
        public int id;

        [DataMember]
        public string text;

        [DataMember]
        public List<Variant> variantList;
    }
}