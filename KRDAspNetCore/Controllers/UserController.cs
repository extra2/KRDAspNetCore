using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using KRDAspNetCore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace KRDAspNetCore.Controllers
{
    public class UserController : Controller
    {
        private AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET /user/1
        [HttpGet]
        [Route("user/{id}")]
        public User GetUser(int id) // works
        {
            return _context.Users.FirstOrDefault(u => u.ID == id);
        }
        // GET /user/
        [HttpGet]
        [Route("user")]
        public IEnumerable<User> GetAllUsers() // works
        {
            return _context.Users.ToList();
        }
        // POST /user
        [HttpPost]
        [Route("user")]
        public User CreateUser(User _user) // works
        {
            _context.Users.Add(_user);
            _context.SaveChanges();
            return _user;
        }
        // PUT /user
        [HttpPut]
        [Route("user")]
        public void UpdateUser(User _user) // works
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.ID == _user.ID);

            if (userInDb == null) throw new HttpRequestException();

            userInDb.Name = _user.Name;
            userInDb.Surname = _user.Surname;
            userInDb.Login = _user.Login;
            userInDb.Password = _user.Password;
            userInDb.Role = _user.Role;
            userInDb.Password = _user.Password;
            userInDb.Street = _user.Street;

            _context.SaveChanges();
        }
        // DELETE /user/1
        [HttpDelete]
        [Route("user/{id}")]
        public void DeleteUser(int id) // works
        {
            var userInDb = _context.Users.SingleOrDefault(u => u.ID == id);

            if (userInDb == null) throw new HttpRequestException();

            _context.Users.Remove(userInDb);
            _context.SaveChanges();
        }
    }
}