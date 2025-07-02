using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.ViewModel;

namespace PRJ_SWD.Business.Service.StaffService
{
    public interface IStaffService
    {
        List<StaffViewModel> GetAllStaff();
    }
}
