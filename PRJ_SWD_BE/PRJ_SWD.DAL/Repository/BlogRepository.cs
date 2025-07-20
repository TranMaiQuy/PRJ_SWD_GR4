using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace PRJ_SWD.DAL.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private PrjSwdContext _context;
       
        public BlogRepository(PrjSwdContext context)
        {
            _context = context;
        }
        public void Add(Blog blog)
        {
           

           _context.Blogs.Add(blog);
           
        }

        

        public void Delete(int id)
        {
            var blog = GetById(id);
            _context.Blogs.Remove(blog);
        }

        public Blog GetById(int id)
        {
            return _context.Blogs.FirstOrDefault(b => b.BlogId == id);
        }

        public List<Blog> List()
        {
            var result = _context.Blogs
         .Include(b => b.Category)
         .Include(b => b.Person).ToList();

            return result;
        }

        public void Update(Blog blog)
        {
           
            _context.Blogs.Update(blog);

        }
       
    }
}
