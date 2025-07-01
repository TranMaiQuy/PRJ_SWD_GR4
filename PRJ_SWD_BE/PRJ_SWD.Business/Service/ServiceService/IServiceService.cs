using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.ViewModel;

namespace PRJ_SWD.Business.Service.ServiceService
{
    public interface IServiceService
    {
        
        List<ServiceViewModel> GetAllService();
   
    }
}
