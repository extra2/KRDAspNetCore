using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using KRDAspNetCore.Model;
using Microsoft.AspNetCore.Mvc;

namespace KRDAspNetCore.Controllers
{
    public class PackageController : Controller
    {
        public AppDbContext _context; 
        public PackageController(AppDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /package/1
        [HttpGet]
        [Route("package/{id}")]
        public Packages GetPackage(int id) // works
        {
            return _context.Packages.FirstOrDefault(u => u.ID == id);
        }
        // GET /package/
        [HttpGet]
        [Route("package")]
        public IEnumerable<Packages> GetAppPackages() // works
        {
            return _context.Packages.ToList();
        }
        // POST /package
        [HttpPost]
        [Route("package")]
        public Packages CreateUser(Packages _package) // works
        {
            _context.Packages.Add(_package);
            _context.SaveChanges();
            return _package;
        }
        // PUT /package
        [HttpPut]
        [Route("package")]
        public void UpdateUser(Packages _package) // works
        {
            var packageInDb = _context.Packages.FirstOrDefault(u => u.ID == _package.ID);

            if (packageInDb == null) throw new HttpRequestException();

            packageInDb.IdUser = _package.IdUser;
            packageInDb.StatucChangedDate = _package.StatucChangedDate;
            packageInDb.Status = _package.Status;

            _context.SaveChanges();
        }

        // DELETE /package/1
        [HttpDelete]
        [Route("package/{id}")]
        public void DeleteUser(int id) // works
        {
            var packageInDb = _context.Packages.SingleOrDefault(u => u.ID == id);

            if (packageInDb == null) throw new HttpRequestException();

            _context.Packages.Remove(packageInDb);
            _context.SaveChanges();
        }
    }
}