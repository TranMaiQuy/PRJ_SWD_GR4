using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.Application.ViewModel;
using PRJ_SWD.Application.DTO;

namespace PRJ_SWD.Business.Service.ServiceService
{
    public interface IServiceService
    {
        void Create(ServiceCreateDto dto);
        void Delete(int id);
        ServiceViewModel? GetById(int id);
        List<ServiceViewModel> GetAll();
        void Update(ServiceUpdateDto dto);
    }
}
