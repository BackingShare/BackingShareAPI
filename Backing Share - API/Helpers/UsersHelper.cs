using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Backing_Share___API.Models;
using Backing_Share___API.Repositories;

namespace Backing_Share___API.Helpers
{
    public class UsersHelper : IUsersHelper
    {
        private IUsersRepository _usersRepository;

        public UsersHelper(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public void CreateUser(User user)
        {
            byte[] salt = new byte[16];

            new RNGCryptoServiceProvider().GetBytes(salt);
            var pbkdf2 = new Rfc2898DeriveBytes(user.password, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string passwordHash = Convert.ToBase64String(hashBytes);

            _usersRepository.CreateUser(user, passwordHash);
            
        }

        public List<Users> GetAllUsers()
        {
            List<Users> users = _usersRepository.GetAllUsers();
            return users;
        }

        public User GetUserByUsername(string username)
        {
            User user = _usersRepository.GetUserByUsername(username);
            return user;
        }

        public bool VerifyUserPassword(User user)
        {
            
            User dbUser = this.GetUserByUsername(user.Username);
            if (dbUser != null)
            {
                string savedPasswordHash = dbUser.password.ToString();
                byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                var pbkdf2 = new Rfc2898DeriveBytes(user.password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                bool ok = true;

                for(int i=0; i < 20; i++)
                {
                    if(hashBytes[i + 16] != hash[i])
                    {
                        ok = false;
                    }

                }
                return ok;
            }
            else
            {
                throw new Exception("User not in database");
            }
            
           
        }
    }
}
