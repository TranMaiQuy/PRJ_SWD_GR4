using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Repository;
using PRJ_SWD.Application.ViewModel;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;
using DALService = PRJ_SWD.DAL.Models.Service;


namespace PRJ_SWD.Business.Service.ServiceService
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public ServiceService(IServiceRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Create(ServiceCreateDto dto)
        {
            var service = new DALService
            {
                ServiceName = dto.ServiceName,
                Price = dto.Price,
                Description = dto.Description,
                Status = dto.Status,
                Image = dto.Image,
                Duration = dto.Duration,
                Detail = dto.Detail,
                ManagerId = dto.ManagerId
            };

            repository.Add(service);
            unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            repository.Delete(id);
            unitOfWork.Commit();
        }

        public ServiceViewModel? GetById(int id)
        {
            var service = repository.GetById(id);
            if (service == null) return null;

            return new ServiceViewModel
            {
                ServiceId = service.ServiceId,
                ServiceName = service.ServiceName,
                Price = service.Price,
                Description = service.Description,
                Status = service.Status,
                Image = service.Image,
                Duration = service.Duration,
                Detail = service.Detail,
                ManagerName = service.Manager?.PersonName ?? "Unknown"
            };
        }

        public List<ServiceViewModel> GetAll()
        {
            return repository.GetAll().Select(service => new ServiceViewModel
            {
                ServiceId = service.ServiceId,
                ServiceName = service.ServiceName,
                Price = service.Price,
                Description = service.Description,
                Status = service.Status,
                Image = service.Image,
                Duration = service.Duration,
                Detail = service.Detail,
                ManagerName = service.Manager?.PersonName ?? "Unknown"
            }).ToList();
        }

        public void Update(ServiceUpdateDto dto)
        {
            var service = repository.GetById(dto.ServiceId);
            if (service == null) return;

            service.ServiceName = dto.ServiceName;
            service.Price = dto.Price;
            service.Description = dto.Description;
            service.Status = dto.Status;
            service.Image = dto.Image;
            service.Duration = dto.Duration;
            service.Detail = dto.Detail;
            service.ManagerId = dto.ManagerId;

            repository.Update(service);
            unitOfWork.Commit();
        }
    }
}
