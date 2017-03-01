using NewsPortal.Core.Infrastructure;
using NewsPortal.Data.DataContext;
using NewsPortal.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly NewsContext _context = new NewsContext();
        public int Count()
        {
            return _context.Users.Count();
        }

        public void Delete(int id)
        {
            var User = GetById(id);
            if (User != null)
            {
                _context.Users.Remove(User);
            }
        }

        public User Get(Expression<Func<User, bool>> expression)
        {
            return _context.Users.FirstOrDefault(expression);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.Select(x => x);
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == id);
        }

        public IQueryable<User> GetMany(Expression<Func<User, bool>> expression)
        {
            return _context.Users.Where(expression);
        }

        public void Insert(User obj)
        {
            _context.Users.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User obj)
        {
            _context.Users.AddOrUpdate(obj);
        }
    }
}
