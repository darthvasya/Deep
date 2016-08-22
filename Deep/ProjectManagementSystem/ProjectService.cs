using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Deep.ProjectManagementSystem
{
    public class ProjectService
    {
        DB_A0BEB4_deepEntities dbContext = new DB_A0BEB4_deepEntities();

        public bool addProject(Projects project)
        {
            dbContext.Projects.Add(project);
            return true;
        }

        public List<Projects> getProjectList()
        {
            return dbContext.Projects.ToList();
        }

        public Projects getProjectById(string id)
        {
            try
            {
                int intId = 0;
            }
            catch
            {

            }
            return null;
        }
        
    }
}