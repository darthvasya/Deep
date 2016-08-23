using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using Deep.QuestionManagementSystem;

namespace Deep.ProjectManagementSystem
{
    public class ProjectService : IProjectService
    {
        DB_A0BEB4_deepEntities dbContext = new DB_A0BEB4_deepEntities();

        public bool addProject(Project project)
        {
            try
            {
                dbContext.Project.Add(project);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<ProjectWrapper> getProjectList()
        {
            List<Project> projects = dbContext.Project.ToList();
            List<ProjectWrapper> result = new List<ProjectWrapper>();
            foreach(Project project in projects){
                ProjectWrapper projectWrapper = new ProjectWrapper();
                projectWrapper.id = project.id;
                projectWrapper.name = project.name;
                projectWrapper.peopleCount = dbContext.Survey.Where(p => p.project_id == project.id).ToList().Count;
                result.Add(projectWrapper);
            }
            return result;
        }

        public Project getProject(string id)
        {
            Project project;
            try
            {
                int id_int = Convert.ToInt32(id);
                project = dbContext.Project.Where(p => p.id == id_int).FirstOrDefault();
            }
            catch
            {
                return null;
            }
            return project;
        }

        private List<QuestionWrapperWithVariants> getQuestionList(int p_id)
        {
            List<QuestionWrapperWithVariants> result = new List<QuestionWrapperWithVariants>();
            List<Question> questions = dbContext.Question.Where(p => p.project_id == p_id).ToList();
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

        public ProjectWrapperWithQuestions getProjectWithQuestionsById(string id)
        {
            ProjectWrapperWithQuestions result;
            try
            {
                int intId = Int32.Parse(id);
                Project project = dbContext.Project.Where(p => p.id == intId).FirstOrDefault();
                result = new ProjectWrapperWithQuestions();
                result.id = project.id;
                result.name = project.name;
                result.description = project.description;
                result.questionList = null;//getQuestionList(intId);
            }
            catch
            {
                result = null;
            }
            return result;
        }

        public List<Survey> projectSurveys(string id)
        {
            List<Survey> surveys = new List<Survey>();
            try
            {
                int id_int = Convert.ToInt32(id);
                surveys = dbContext.Survey.Where(p => p.project_id == id_int).ToList();
                surveys.Reverse();
                return surveys;
            }
            catch
            {
                return null;
            }
        }

        public Survey projectSurvey(string id_s)
        {
            Survey survey = new Survey();
            try
            {
                int id_s_int = Convert.ToInt32(id_s);
                survey = dbContext.Survey.Where(p => p.id == id_s_int).FirstOrDefault();
                return survey;
            }
            catch
            {
                return null;
            }
        }

        public Survey addSurvey(Survey survey)
        {
            try
            {
                if (survey == null)
                    return null;
                else
                {
                    dbContext.Survey.Add(survey);
                    dbContext.SaveChanges();
                }
                return survey;
            }
            catch
            {
                return null;
            }
        }
    }
}
