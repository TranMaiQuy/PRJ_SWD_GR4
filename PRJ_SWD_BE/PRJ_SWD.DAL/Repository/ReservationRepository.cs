using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PRJ_SWD.DAL.DTO;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.ViewModel;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace PRJ_SWD.DAL.Repository
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private readonly PrjSwdContext _context;
        public ReservationRepository(PrjSwdContext context)
        {
            _context = context;
        }

        public void Add(ReservationCreateDto entity)
        {
            var reservation = new Reservation
            {
                CustomerId = entity.CustomerId,
                StaffId = entity.StaffId,
                CreatedDate = DateOnly.FromDateTime(DateTime.Now),
                Status = 0,
                ReservationDate = entity.ReservationDate,
                Note = entity.Note,
            };
            for (int i = 0; i < entity.ServiceIds.Count; i++) {
                var service = _context.Services.Find(entity.ServiceIds[i]);
                if (service != null) reservation.Services.Add(service);
            }
            _context.Reservations.Add(reservation);

        }

        public Reservation Delete(Reservation entity)
        {
            _context.Reservations.Remove(entity);
            return entity;
        }

        public Reservation Delete(int id)
        {
            var entity = _context.Reservations.Find(id);
            if (entity != null)
            {
                _context.Reservations.Remove(entity);
            }
            return entity;
        }

        public ReservationViewModel GetById(int id)
        {
            var reservation = _context.Reservations
     .Include(r => r.Services)
     .FirstOrDefault(r => r.ReservationId == id);

            if (reservation == null)
                return null;

            // Tìm nhân viên (Staff) có RoleId = 2 và StaffId khớp với CustomerId trong Reservation
            var staff = _context.Accounts
                .FirstOrDefault(a => a.PersonId == reservation.StaffId);
            var customer = _context.Accounts.FirstOrDefault( a => a.PersonId == reservation.CustomerId);

            var result = new ReservationViewModel
            {
                ReservationId = reservation.ReservationId,
                ReservationDate = reservation.ReservationDate?.ToString("yyyy-MM-dd"),
                Note = reservation.Note,
                StaffName = staff?.PersonName ?? "Unknown staff", // fallback nếu không tìm thấy
                CustomerName = customer?.PersonName ?? "Unknown Cusstomer",
                Services = reservation.Services.Select(s => new ServiceViewModel
                {
                    ServiceId = s.ServiceId,
                    ServiceName = s.ServiceName
                }).ToList()
            };

            return result;

        }

        public List<Reservation> List()
        {
            return _context.Reservations.ToList();
        }

        public void Update(Reservation entity)
        {
            _context.Reservations.Update(entity);
        }

        public Reservation Update(int id, Reservation entity)
        {
            throw new NotImplementedException();
        }

        Reservation IRepository<Reservation>.Add(Reservation entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<Reservation>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Reservation IRepository<Reservation>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
