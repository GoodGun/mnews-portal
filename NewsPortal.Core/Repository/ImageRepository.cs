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
    public class ImageRepository : IImageRepository
    {
        private readonly NewsContext _context = new NewsContext();
        public int Count()
        {
            return _context.Images.Count();
        }

        public void Delete(int id)
        {
            var Image = GetById(id);
            if (Image != null)
            {
                _context.Images.Remove(Image);
            }
        }

        public Image Get(Expression<Func<Image, bool>> expression)
        {
            return _context.Images.FirstOrDefault(expression);
        }

        public IEnumerable<Image> GetAll()
        {
            return _context.Images.Select(x => x);
        }

        public Image GetById(int id)
        {
            return _context.Images.FirstOrDefault(x => x.ImageId == id);
        }

        public IQueryable<Image> GetMany(Expression<Func<Image, bool>> expression)
        {
            return _context.Images.Where(expression);
        }

        public void Insert(Image obj)
        {
            _context.Images.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Image obj)
        {
            _context.Images.AddOrUpdate(obj);
        }
    }
}
