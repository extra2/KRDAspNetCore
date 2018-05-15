using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KRDAspNetCore.Model;

namespace KRDAspNetCore.Repository
{
    public class UserRepository: IUserRepository, IDisposable
    {
        private AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.ID == id);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool UpdateUser(User user)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.ID == user.ID);

            if (userInDb == null) return false;

            userInDb.Name = user.Name;
            userInDb.Surname = user.Surname;
            userInDb.Login = user.Login;
            userInDb.Password = user.Password;
            userInDb.Role = user.Role;
            userInDb.Password = user.Password;
            userInDb.Street = user.Street;

            _context.SaveChanges();

            return true;
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.ID == id);
            if (user == null) return;
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
