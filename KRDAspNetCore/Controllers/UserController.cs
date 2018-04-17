using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KRDAspNetCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;

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
        [HttpGet]
        [Route("user/{id}")]
        public IActionResult GetUser(int id)
        {
            _context.Users.Add(new User() { Login = "login", Name = "name" });
            _context.SaveChanges();


            var user = _context.Users.FirstOrDefault(u => u.ID == id);
            if (user != null) return Content("User " + user.Name + " found!");
            return Content("User " + id + " does not exist");
        }

        [HttpPost]
        [Route("user/{name?}")]
        public IActionResult PostUser(string name, string surname, string street, string login, string password, string role)
        {
            return new BadRequestResult();
        }

        [HttpPut]
        [Route("user/{name?}")]
        public IActionResult PutUser(string name)
        {
            return Content("User " + name);
        }

        [HttpDelete]
        [Route("user/{name?}")]
        public IActionResult DeleteUser(string name)
        {
            return Content("User " + name);
        }
    }
}