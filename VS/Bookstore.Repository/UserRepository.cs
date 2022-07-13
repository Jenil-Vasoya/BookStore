using Bookstore.models.Models;
using Bookstore.models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Repository
{
    public class UserRepository : BaseRepository
    {
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User Login(LoginModel model)
        {
           return _context.Users.FirstOrDefault(c => c.Email.Equals(model.Email.ToLower()) && c.Password.Equals(model.Password));
        }

        public User Register(RegisterModel model)
        {
            User user = new User()
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email,
                Password = model.Password,
                RoleId = model.Roleid,
            };
            var add = _context.Users.Add(user);
            _context.SaveChanges();
            return add.Entity;
        }

        public User UpdateUsers(User user)
        {
            var add = _context.Users.Update(user);
            _context.SaveChanges();
            return add.Entity;
        }

        public bool DeleteUsers(int id)
        {
            var user = _context.Users.FirstOrDefault(c => c.Id == id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}
