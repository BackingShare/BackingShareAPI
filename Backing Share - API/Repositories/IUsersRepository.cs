using System.Collections.Generic;
using Backing_Share___API.Models;

namespace Backing_Share___API.Repositories
{
    public interface IUsersRepository
    {
        void CreateUser(User userInfo, string passwordHash);
        User GetUserByUsername(string username);
        List<Users> GetAllUsers();
    }
}