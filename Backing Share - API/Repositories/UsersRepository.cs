using System.Collections.Generic;
using System.Linq;
using Backing_Share___API.Models;

namespace Backing_Share___API.Repositories
{
    public class UsersRepository : IUsersRepository
    {
     
        public UsersRepository()
        {
        }

        public void CreateUser(User userInfo, string passwordHash)
        {
            using (BackingShareContext db = new BackingShareContext())
            {
                Users dbUser = new Users()
                {
                    Username = userInfo.Username,
                    Email = userInfo.Email,
                    PasswordHash = passwordHash,
                    
                };
                db.Users.Add(dbUser);

                db.SaveChanges();
                
            }
            
        }

        public List<Users> GetAllUsers()
        {
            using (BackingShareContext db = new BackingShareContext())
            {
                List<Users> dbUsers = db.Users.ToList();
                return dbUsers;
            }
        }

        public User GetUserByUsername(string username)
        {
           
            using(BackingShareContext db = new BackingShareContext())
            {
                var userDb = db.Users.FirstOrDefault(x => x.Username == username);

                User user = new User()
                {
                    Username = userDb.Username,
                    Email = userDb.Email,
                    password = userDb.PasswordHash
                    
                };
                return user;
            }
            
        }
    }
}
