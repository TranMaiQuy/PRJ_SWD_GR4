using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.ViewModel;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.Repository;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.DTO;

namespace PRJ_SWD.Business.Service.BlogService
{
    public class BlogService : IBlogService
    {
        public BlogRepository repository;
        public IUnitOfWork unitOfWork;
      public BlogService(BlogRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public async Task AddBlog(BlogDto reservation)
        {
            await repository.AddAsync(reservation);
            await unitOfWork.CommitAsync(); // nếu Commit là async
        }

        public void DeleteBlog(int id)
        {
            repository.Delete(id);
            unitOfWork.Commit();
        }

        public List<BlogViewModel> GetAllBlog()
        {
          return  repository.List();
        }

        public Blog GetBlogById(int id)
        {
           return repository.GetById(id);
        }

        public Blog UpdateBlog(int id, BlogDto blog)
        {
            var blogDto = repository.Update(id, blog);
            unitOfWork.Commit();
            return blogDto;
        }
    }
}
