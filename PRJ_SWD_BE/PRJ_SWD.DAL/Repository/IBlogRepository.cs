using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.DTO;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.ViewModel;

namespace PRJ_SWD.DAL.Repository
{
    public interface IBlogRepository
    {
        Task AddAsync(BlogDto dto);
        Blog GetById(int id);
        void Delete(int id);
        List<BlogViewModel> List();
        Blog Update(int id, BlogDto dto);
    }
}
