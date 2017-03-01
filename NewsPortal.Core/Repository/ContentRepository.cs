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
    public class ContentRepository : IContentRepository
    {
        private readonly NewsContext _context = new NewsContext();
        public int Count()
        {
            return _context.Contents.Count();
        }

        public void Delete(int id)
        {
            var Content = GetById(id);
            if (Content != null)
            {
                _context.Contents.Remove(Content);
            }
        }

        public Content Get(Expression<Func<Content, bool>> expression)
        {
            return _context.Contents.FirstOrDefault(expression);
        }

        public IEnumerable<Content> GetAll()
        {                      
            return _context.Contents.Select(x => x);
        }

        public Content GetById(int id)
        {
            return _context.Contents.FirstOrDefault(x => x.ContentId == id);
        }

        public IQueryable<Content> GetMany(Expression<Func<Content, bool>> expression)
        {
            return _context.Contents.Where(expression);
        }

        public void Insert(Content obj)
        {
            _context.Contents.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Content obj)
        {
            _context.Contents.AddOrUpdate(obj);
        }
    }
}
