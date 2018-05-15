using KRDAspNetCore.Model;
using System.Collections.Generic;

namespace KRDAspNetCore.Repository
{
    public interface IPackagesRepository
    {
        Packages GetPackage(int id);
        List<Packages> GetAppPackages();
        Packages CreatePackage(Packages _package);
        bool UpdatePackage(Packages _package);
        void DeletePackage(int id);
    }
}