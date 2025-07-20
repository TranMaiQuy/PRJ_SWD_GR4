using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.Application.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace PRJ_SWD.DAL.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly PrjSwdContext _context;
        public ServiceRepository(PrjSwdContext context)
        {
            _context = context;
        }

        public void Add(Service service)
        {
            _context.Services.Add(service);
        }

        public void Delete(int id)
        {
            var service = _context.Services
                .Include(s => s.Reservations)
                .FirstOrDefault(s => s.ServiceId == id);
            if (service == null) return;

            service.Reservations.Clear(); // xoá quan hệ N-N
            _context.Services.Remove(service);
        }

        public Service? GetById(int id)
        {
            return _context.Services.Include(s => s.Manager).FirstOrDefault(s => s.ServiceId == id);
        }

        public List<Service> GetAll()
        {
            return _context.Services.Include(s => s.Manager).ToList();
        }

        public Service Update(Service service)
        {
            _context.Services.Update(service);
            return service;
        }

        public Account? GetManager(int managerId)
        {
            return _context.Accounts.FirstOrDefault(a => a.PersonId == managerId);
        }
    }
}
