
using Backing_Share___API.Helpers;
using Backing_Share___API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Backing_Share___API.Controllers
{
    [Route("[controller]/[action]")]
    [EnableCors("AllowAll")]
    public class UsersController : Controller
    {
        private IUsersHelper _userHelper;

        public UsersController(IUsersHelper userHelper)
        {
            _userHelper = userHelper;
        }

        [HttpGet]
        public List<Users> Get()
        {
            List <Users> users = _userHelper.GetAllUsers();
            return users;
        }

        public User GetByUsername(string username)
        {
            User user = _userHelper.GetUserByUsername(username);
            return user;
        }
        [HttpPost]
        public bool VerifyUserPassword([FromBody] User user)
        {
            bool confirmation = _userHelper.VerifyUserPassword(user);
            return confirmation;
        }



        [HttpPost]
        public IActionResult Create([FromBody]User user)
        {
            try
            {
                _userHelper.CreateUser(user);
                return Ok();
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}