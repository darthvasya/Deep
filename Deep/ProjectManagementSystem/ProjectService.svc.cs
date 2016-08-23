//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
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
            dbContext.Project.Add(project);
            dbContext.SaveChanges();
            return true;
        }

        public List<ProjectWrapper> getProjectList()
        {
            List<Project> projects = dbContext.Project.ToList();
            List<ProjectWrapper> result = new List<ProjectWrapper>();
            foreach(Project project in projects){
                ProjectWrapper projectWrapper = new ProjectWrapper();
                projectWrapper.id = project.id;
                projectWrapper.name = project.name;
                projectWrapper.peopleCount = dbContext.Survey.ToList().Count;
                result.Add(projectWrapper);
            }
            return result;
        }

        public Project getProjectById(string id)
        {
            Project project;
            try
            {
                int intId = Int32.Parse(id);
                project = dbContext.Project.Where(p => p.id == intId).FirstOrDefault();
            }
            catch
            {
                project = null;
            }
            return null;
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
                result.questionList = getQuestionList(intId);
            }
            catch
            {
                result = null;
            }
            return result;
        }
    }
}
