using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.ViewModel;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.DTO;

namespace PRJ_SWD.Business.Service.BlogService
{
    internal interface IBlogService
    {
       Task AddBlog(BlogDto reservation);
        void DeleteBlog(int id);
       Blog UpdateBlog(int id, BlogDto blog);
        List<BlogViewModel> GetAllBlog();
        Blog GetBlogById(int id);
    }
}
