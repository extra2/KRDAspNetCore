using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using KRDAspNetCore.Model;
using KRDAspNetCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace KRDAspNetCore.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepository;


        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        // GET /user/1
        [HttpGet]
        [Route("user/{id}")]
        public User GetUser(int id) // works
        {
            return userRepository.GetUserById(id);
        }
        // GET /user/
        [HttpGet]
        [Route("user")]
        public IEnumerable<User> GetAllUsers() // works
        {
            return userRepository.GetAllUsers();
        }
        // POST /user
        [HttpPost]
        [Route("user")]
        public User CreateUser(User _user) // works
        {
            return userRepository.AddUser(_user);
        }
        // PUT /user
        [HttpPut]
        [Route("user")]
        public void UpdateUser(User _user) // works
        {
            if(!userRepository.UpdateUser(_user)) throw new HttpRequestException();
        }
        // DELETE /user/1
        [HttpDelete]
        [Route("user/{id}")]
        public void DeleteUser(int id) // works
        {
            userRepository.DeleteUser(id);
        }
    }
}