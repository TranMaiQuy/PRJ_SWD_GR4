using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.ViewModel;

namespace PRJ_SWD.DAL.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private PrjSwdContext _context;

        public StaffRepository(PrjSwdContext context)
        {
            _context = context;
        }
      

        public List<StaffViewModel> List()
        {
            var list = _context.Accounts
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
