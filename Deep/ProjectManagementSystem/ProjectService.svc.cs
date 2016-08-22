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

        public List<Projects> getProjectList()
        {
            return dbContext.Projects.ToList();
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
