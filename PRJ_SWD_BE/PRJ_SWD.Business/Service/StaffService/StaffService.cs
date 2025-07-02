using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Repository;
using PRJ_SWD.DAL.ViewModel;

namespace PRJ_SWD.Business.Service.StaffService
{
    public class StaffService : IStaffService
    {
        public StaffRepository repository;
        public StaffService(StaffRepository repository)
        {
            this.repository = repository;
        }
        public List<StaffViewModel> GetAllStaff()
        {
            return repository.List();
        }
    }
}
