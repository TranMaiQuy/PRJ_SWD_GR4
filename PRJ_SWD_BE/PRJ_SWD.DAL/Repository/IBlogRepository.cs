using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.Application.ViewModel;

namespace PRJ_SWD.DAL.Repository
{
    public interface IBlogRepository
    {
        void Add(Blog dto);
        Blog GetById(int id);
        void Delete(int id);
        List<Blog> List();
        Blog Update( Blog dto);
    }
}
