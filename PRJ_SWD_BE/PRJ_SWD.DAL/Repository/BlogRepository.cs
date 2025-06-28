using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PRJ_SWD.DAL.DTO;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;

namespace PRJ_SWD.DAL.Repository
{
    public class BlogRepository : IRepository<Blog>
    {
        private PrjSwdContext _context;
        public BlogRepository(PrjSwdContext context)
        {
            _context = context;
        }
        public Blog Add(Blog entity)
        {
            throw new NotImplementedException();
        }

        public Blog Delete(Blog entity)
        {
            throw new NotImplementedException();
        }

        public Blog Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Blog GetById(int id)
        {
            return _context.Blogs.FirstOrDefault(b => b.BlogId == id);
        }

        public List<BlogDTO> List()
        {
            var result = _context.Blogs
         .Include(b => b.Category)
         .Include(b => b.Person)
         .Select(b => new BlogDTO         {
             BlogId = b.BlogId,
             Title = b.Title,
             Description = b.Description,
             Content = b.Content,
             Image = b.Image,
             CreatedDate = b.CreatedDate,
             PersonName = b.Person.PersonName,
             CategoryName = b.Category.CategoryName
         }).ToList();

            return result;
        }

        public void Update(Blog entity)
        {
            throw new NotImplementedException();
        }

        List<Blog> IRepository<Blog>.List()
        {
            throw new NotImplementedException();
        }
    }
}
