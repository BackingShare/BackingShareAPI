using Backing_Share___API.Models;
using Backing_Share___API.Repositories;
using System.Collections.Generic;

namespace Backing_Share___API.Helpers
{
    public class ProjectsHelper : IProjectsHelper
    {
        private IProjectsRepository _projectsRepository;
        public ProjectsHelper(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public void Create(ProjectsModel projectModel)
        {
            _projectsRepository.Create(projectModel);
        }

        public List<ProjectsModel> GetAllProjects()
        {
            List<ProjectsModel> projects = _projectsRepository.GetAllProjects();
            return projects;
        }

        public List<ProjectsModel> GetProjectsByUserId(int userId)
        {
            List<ProjectsModel> projects = _projectsRepository.GetProjectsByUserId(userId);
            return projects;
        }
    }
}
