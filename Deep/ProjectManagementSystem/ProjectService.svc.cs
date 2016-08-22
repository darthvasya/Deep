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

namespace Deep.ProjectManagementSystem
{
    public class ProjectService : IProjectService
    {
        DB_A0BEB4_deepEntities dbContext = new DB_A0BEB4_deepEntities();

        public bool addProject(Projects project)
        {
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();
            return true;
        }

        public List<ProjectWrapper> getProjectList()
        {
            List<Projects> projects = dbContext.Projects.ToList();
            List<ProjectWrapper> result = new List<ProjectWrapper>();
            foreach(Projects project in projects){
                ProjectWrapper projectWrapper = new ProjectWrapper();
                projectWrapper.id = project.id;
                projectWrapper.name = project.name;
                projectWrapper.peopleCount = dbContext.Surveys.ToList().Count;
            }
            return result;
        }

        public Projects getProjectById(string id)
        {
            Projects project;
            try
            {
                int intId = Int32.Parse(id);
                project = dbContext.Projects.Where(p => p.id == intId).FirstOrDefault();
            }
            catch
            {
                project = null;
            }
            return null;
        }
    }
}
