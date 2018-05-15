using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using KRDAspNetCore.Model;
using KRDAspNetCore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KRDAspNetCore.Controllers
{
    public class PackageController : Controller
    {
        private IPackagesRepository _packagesRepository;
        public PackageController(IPackagesRepository packagesRepository)
        {
            this._packagesRepository = packagesRepository;
        }

        // GET /package/1
        [HttpGet]
        [Route("package/{id}")]
        public Packages GetPackage(int id) // works
        {
            return _packagesRepository.GetPackage(id);
        }
        // GET /package/
        [HttpGet]
        [Route("package")]
        public IEnumerable<Packages> GetAppPackages() // works
        {
            return _packagesRepository.GetAppPackages();
        }
        // POST /package
        [HttpPost]
        [Route("package")]
        public Packages CreatePackage(Packages _package) // works
        {
            return _packagesRepository.CreatePackage(_package);
        }
        // PUT /package
        [HttpPut]
        [Route("package")]
        public void UpdatePackage(Packages _package) // works
        {

            if (!_packagesRepository.UpdatePackage(_package)) throw new HttpRequestException();
        }

        // DELETE /package/1
        [HttpDelete]
        [Route("package/{id}")]
        public void DeletePackage(int id) // works
        {
            _packagesRepository.DeletePackage(id);
        }
    }
}