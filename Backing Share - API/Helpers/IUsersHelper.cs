using System.Collections.Generic;
using Backing_Share___API.Models;

namespace Backing_Share___API.Helpers
{
    public interface IUsersHelper
    {
        User GetUserByUsername(string username);
        void CreateUser(User user);
        List<Users> GetAllUsers();
        bool VerifyUserPassword(User user);
    }
}