using System.Collections.Generic;
using KRDAspNetCore.Model;

namespace KRDAspNetCore.Repository
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> GetAllUsers();
        User AddUser(User user);
        bool UpdateUser(User user);
        void DeleteUser(int id);
    }
}