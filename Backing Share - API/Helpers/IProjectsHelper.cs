using System.Collections.Generic;
using Backing_Share___API.Models;

namespace Backing_Share___API.Helpers
{
    public interface IProjectsHelper
    {
        void Create(ProjectsModel projectModel);
        List<ProjectsModel> GetProjectsByUserId(int userId);
        List<ProjectsModel> GetAllProjects();
    }
}