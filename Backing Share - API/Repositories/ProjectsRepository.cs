using System.Collections.Generic;
using System.Linq;
using Backing_Share___API.Models;

namespace Backing_Share___API.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        public void Create(ProjectsModel projectModel)
        {
            using (BackingShareContext db = new BackingShareContext())
            {
                Projects dbProject = new Projects()
                {
                    name = projectModel.name,
                    isPublic = projectModel.isPublic,
                    Id = projectModel.userId
                };
                db.Projects.Add(dbProject);
            }
        }

        public List<ProjectsModel> GetAllProjects()
        {
            List<ProjectsModel> projects = new List<ProjectsModel>();
            using (BackingShareContext db = new BackingShareContext())
            {
                List<Projects> dbProjects = db.Projects.ToList();
                foreach (Projects dbProject in dbProjects)
                {
                    ProjectsModel project = new ProjectsModel()
                    {
                        Id = dbProject.Id,
                        isPublic = dbProject.isPublic,
                        name = dbProject.name,
                        userId = dbProject.userId
                    };
                    projects.Add(project);

                }
                return projects;
            }
        }

        public List<ProjectsModel> GetProjectsByUserId(int userId)
        {
            List<ProjectsModel> projects = new List<ProjectsModel>(); 
            using (BackingShareContext db = new BackingShareContext())
            {
                List<Projects> dbProjects = db.Projects.Where(r=> r.userId == userId).ToList();
                foreach(Projects dbProject in dbProjects)
                {
                    ProjectsModel project = new ProjectsModel()
                    {
                        Id = dbProject.Id,
                        isPublic = dbProject.isPublic,
                        name = dbProject.name,
                        userId = dbProject.userId
                    };
                    projects.Add(project);

                }
                return projects;
            }
        }
    }
}
