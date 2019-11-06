using System.Collections.Generic;
using Backing_Share___API.Models;

namespace Backing_Share___API.Repositories
{
    public interface IProjectsRepository
    {
        void Create(ProjectsModel projectModel);
        List<ProjectsModel> GetProjectsByUserId(int userId);
        List<ProjectsModel> GetAllProjects();
    }
}