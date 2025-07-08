using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Repository;
using PRJ_SWD.Application.ViewModel;

namespace PRJ_SWD.Business.Service.ServiceService
{
    public class ServiceService : IServiceService
    {
        private ServiceRepository repository;
        public ServiceService(ServiceRepository repository)
        {
            this.repository = repository;
        }
        public List<ServiceViewModel> GetAllService()
        {
            var list = repository.List().Select(s => new ServiceViewModel
            {
                ServiceId = s.ServiceId,
                ServiceName = s.ServiceName,
            }).ToList();
            return  list;
        }
    }
}
