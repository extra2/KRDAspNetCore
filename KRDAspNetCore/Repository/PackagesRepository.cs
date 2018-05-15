using System;
using System.Collections.Generic;
using System.Linq;
using KRDAspNetCore.Model;

namespace KRDAspNetCore.Repository
{
    public class PackagesRepository: IPackagesRepository, IDisposable
    {
        private AppDbContext _context;

        public PackagesRepository(AppDbContext context)
        {
            _context = context;
        }

        public Packages GetPackage(int id)
        {
            return _context.Packages.FirstOrDefault(p => p.ID == id);
        }

        public List<Packages> GetAppPackages()
        {
            return _context.Packages.ToList();
        }

        public Packages CreatePackage(Packages _package)
        {
            _context.Packages.Add(_package);
            _context.SaveChanges();
            return _package;
        }

        public bool UpdatePackage(Packages _package)
        {
            var packageInDb = _context.Packages.FirstOrDefault(u => u.ID == _package.ID);

            if (packageInDb == null) return false;

            packageInDb.IdUser = _package.IdUser;
            packageInDb.StatucChangedDate = _package.StatucChangedDate;
            packageInDb.Status = _package.Status;

            _context.SaveChanges();
            return true;
        }

        public void DeletePackage(int id)
        {
            var package = _context.Packages.FirstOrDefault(p => p.ID == id);
            if (package == null) return;
            _context.Packages.Remove(package);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}