using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.Application.ViewModel;

namespace PRJ_SWD.DAL.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private PrjSwdContext _context;

        public StaffRepository(PrjSwdContext context)
        {
            _context = context;
        }
      

        public List<Account> List()
        {
           var list = _context.Accounts.ToList();

            return list;
        }

    }
}
