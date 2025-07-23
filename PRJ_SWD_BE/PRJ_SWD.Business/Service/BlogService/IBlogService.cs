using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.Application.ViewModel;

namespace PRJ_SWD.Business.Service.BlogService
{
    public interface IBlogService
    {
       void AddBlog(BlogDto blog);
        void DeleteBlog(int id);
        void UpdateBlog(BlogDto blog);
        List<BlogViewModel> GetAllBlog();
        Blog GetBlogById(int id);
    }
}
