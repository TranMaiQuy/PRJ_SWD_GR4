using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.Repository;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.Application.ViewModel;

namespace PRJ_SWD.Business.Service.BlogService
{
    public class BlogService : IBlogService
    {
        public IBlogRepository repository;
        public IUnitOfWork unitOfWork;
      public BlogService(IBlogRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public void AddBlog(BlogDto dto)
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
            repository.Add(blog);
          unitOfWork.Commit();
        }

        public void DeleteBlog(int id)
        {
            repository.Delete(id);
            unitOfWork.Commit();
        }

        public List<BlogViewModel> GetAllBlog()
        {
            var list = repository.List()
            .Select(b => new BlogViewModel
            {
                BlogId = b.BlogId,
                Title = b.Title,
                Description = b.Description,
                Content = b.Content,
                Image = b.Image,
                CreatedDate = b.CreatedDate,
                PersonName = b.Person.PersonName,
                CategoryName = b.Category.CategoryName
            }).ToList();
          return  list;
        }

        public Blog GetBlogById(int id)
        {
           return repository.GetById(id);
        }

        public void UpdateBlog(BlogDto dto)
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
            var existingBlog = GetBlogById(dto.BlogId);


            existingBlog.Title = dto.Title;
            existingBlog.Content = dto.Content;
            existingBlog.Description = dto.Description;
            existingBlog.Image = fileName;
            existingBlog.CategoryId = dto.CategoryId;
            existingBlog.PersonId = dto.PersonId;
            existingBlog.CreatedDate = DateOnly.FromDateTime(dto.CreatedDate);
           repository.Update(existingBlog);
            unitOfWork.Commit();
         
        }
    }
}
