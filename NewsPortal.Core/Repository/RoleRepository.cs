using NewsPortal.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Data.Model;
using System.Linq.Expressions;
using NewsPortal.Data.DataContext;
using System.Data.Entity.Migrations;

namespace NewsPortal.Core.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly NewsContext _context = new NewsContext();
        public int Count()
        {
            return _context.Roles.Count();
        }

        public void Delete(int id)
        {
            var Role = GetById(id);
            if (Role != null)
            {
                _context.Roles.Remove(Role);
            }
        }

        public Role Get(Expression<Func<Role, bool>> expression)
        {
            return _context.Roles.FirstOrDefault(expression);
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles.Select(x => x);
        }

        public Role GetById(int id)
        {
            return _context.Roles.FirstOrDefault(x => x.RoleId == id);
        }

        public IQueryable<Role> GetMany(Expression<Func<Role, bool>> expression)
        {
            return _context.Roles.Where(expression);
        }

        public void Insert(Role obj)
        {
            _context.Roles.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Role obj)
        {
            _context.Roles.AddOrUpdate(obj);
        }
    }
}
