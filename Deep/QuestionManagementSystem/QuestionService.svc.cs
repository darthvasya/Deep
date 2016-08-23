using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace Deep.QuestionManagementSystem
{
    public class QuestionService : IQuestionService
    {
        DB_A0BEB4_deepEntities dbContext = new DB_A0BEB4_deepEntities();

        public bool addQuestionToProject(Question question, string p_id)
        {
            try
            {
                int intPId = Int32.Parse(p_id);
                question.project_id = intPId;
                dbContext.Question.Add(question);
                dbContext.SaveChanges();
            }
            catch(Exception exc){
                return false;
            }
            return true;
        }

        public bool addVariantToQuestion(Variant variant, string p_id, string q_id)
        {
            try{
                int intQId = Int32.Parse(q_id);
                variant.question_id = intQId;
                dbContext.Variant.Add(variant);
                dbContext.SaveChanges();
                return true;
            }
            catch(Exception exc){
                return false;
            }
        }

        public List<QuestionWrapperWithVariants> getQuestions(string p_id)
        {
            int p_id_int = Convert.ToInt32(p_id);
            List<QuestionWrapperWithVariants> result = new List<QuestionWrapperWithVariants>();
            List<Question> questions = dbContext.Question.Where(p => p.project_id == p_id_int).ToList();
            foreach (Question question in questions)
            {
                QuestionWrapperWithVariants resultQuestion = new QuestionWrapperWithVariants();
                resultQuestion.id = question.id;
                resultQuestion.text = question.text;
                resultQuestion.variantList = dbContext.Variant.Where(p => p.question_id == question.id).ToList();
                result.Add(resultQuestion);
            }
            return result;
        }
    }
}
