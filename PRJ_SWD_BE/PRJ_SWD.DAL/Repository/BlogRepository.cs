using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PRJ_SWD.DAL.ViewModel;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace PRJ_SWD.DAL.Repository
{
    public class BlogRepository : IRepository<Blog>
    {
        private PrjSwdContext _context;
       
        public BlogRepository(PrjSwdContext context)
        {
            _context = context;
        }
        public async Task AddAsync(BlogDto dto)
        {
            string fileName = null;

            if (dto.Image != null && dto.Image.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                Directory.CreateDirectory(uploadsFolder); // tạo nếu chưa có

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Image.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Image.CopyToAsync(stream);
                }
            }

            var blog = new Blog
            {
                Title = dto.Title,
                Description = dto.Description,
                Content = dto.Content,
                Image = fileName, // chỉ lưu tên file
                CreatedDate = DateOnly.FromDateTime(DateTime.Now),
                PersonId = dto.PersonId,
                CategoryId = dto.CategoryId
            };

            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
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

        public List<BlogViewModel> List()
        {
            var result = _context.Blogs
         .Include(b => b.Category)
         .Include(b => b.Person)
         .Select(b => new BlogViewModel         {
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

        public Blog Update(int id,BlogDto dto)
        {
            string fileName = null;

            if (dto.Image != null && dto.Image.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                Directory.CreateDirectory(uploadsFolder); // tạo nếu chưa có

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Image.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                     dto.Image.CopyTo(stream);
                }
            }
            var existingBlog = _context.Blogs.FirstOrDefault(b => b.BlogId == id);
          

            existingBlog.Title = dto.Title;
            existingBlog.Content = dto.Content;
            existingBlog.Description = dto.Description;
            existingBlog.Image = fileName;
            existingBlog.CategoryId = dto.CategoryId;
            existingBlog.PersonId = dto.PersonId;
            existingBlog.CreatedDate = DateOnly.FromDateTime(dto.CreatedDate);
            _context.Blogs.Update(existingBlog);
            return existingBlog;
        }

        public void Update(int id, Blog entity)
        {
            throw new NotImplementedException();
        }

        Blog IRepository<Blog>.Add(Blog entity)
        {
            throw new NotImplementedException();
        }

      
      


        List<Blog> IRepository<Blog>.List()
        {
            throw new NotImplementedException();
        }

        Blog IRepository<Blog>.Update(int id, Blog entity)
        {
            throw new NotImplementedException();
        }
    }
}
