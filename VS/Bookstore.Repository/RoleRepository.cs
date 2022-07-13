using Bookstore.models.Models;
using Bookstore.models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Repository
{
    public class RoleRepository : BaseRepository
    {
        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public Role GetRole(int id)
        {
            return _context.Roles.FirstOrDefault(c => c.Id == id);
        }

        public Role AddRole(Role role)
        {
            var entry = _context.Roles.Add(role);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Role UpdateRole(Role role)
        {
            var entry = _context.Roles.Update(role);
            _context.SaveChanges();
            return entry.Entity;
        }

        
    }
}
