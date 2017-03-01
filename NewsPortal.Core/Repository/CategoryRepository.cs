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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NewsContext _context = new NewsContext();
        public int Count()
        {
            return _context.Categories.Count();
        }

        public void Delete(int id)
        {
            var Category = GetById(id);
            if (Category != null)
            {
                _context.Categories.Remove(Category);
            }
        }

        public Category Get(Expression<Func<Category, bool>> expression)
        {
            return _context.Categories.FirstOrDefault(expression);
        }

        public IEnumerable<Category> GetAll()
        {                      
            return _context.Categories.Select(x => x);
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.CategoryId == id);
        }

        public IQueryable<Category> GetMany(Expression<Func<Category, bool>> expression)
        {
            return _context.Categories.Where(expression);
        }

        public void Insert(Category obj)
        {
            _context.Categories.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category obj)
        {
            _context.Categories.AddOrUpdate(obj);
        }
    }
}
