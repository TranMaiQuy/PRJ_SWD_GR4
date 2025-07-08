using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Repository;
using PRJ_SWD.Application.ViewModel;

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
            var list = repository.List()
      .Where(a => a.RoleId == 2 && (a.StaffId == 1 || a.StaffId == 2))
      .Select(a => new StaffViewModel
      {
          PersonId = a.PersonId,
          PersonName = a.PersonName,
          StaffId = a.StaffId
      })
      .ToList();
            return list;
        }
    }
}
