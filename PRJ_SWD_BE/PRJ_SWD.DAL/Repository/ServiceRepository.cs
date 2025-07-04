﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.ViewModel;

namespace PRJ_SWD.DAL.Repository
{
    public class ServiceRepository : IRepository<Service>
    {
        private PrjSwdContext _context;
        public ServiceRepository(PrjSwdContext context)
        {
            _context = context;
        }
        public Service Add(Service entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Service GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ServiceViewModel> List()
        {
            var list = _context.Services.Select(s => new ServiceViewModel
            {
                ServiceId = s.ServiceId,
                ServiceName = s.ServiceName,
            }).ToList();
            return list;
        }

        public Service Update(int id, Service entity)
        {
            throw new NotImplementedException();
        }

        List<Service> IRepository<Service>.List()
        {
            throw new NotImplementedException();
        }
    }
}
