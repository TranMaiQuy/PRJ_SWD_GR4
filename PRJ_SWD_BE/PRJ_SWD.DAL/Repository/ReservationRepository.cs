using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.Application.ViewModel;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace PRJ_SWD.DAL.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly PrjSwdContext _context;
        public ReservationRepository(PrjSwdContext context)
        {
            _context = context;
        }

        public void Add(Reservation reservation)
        {

            _context.Reservations.Add(reservation);

        }


        public void Delete(int id)
        {
            var reservation = _context.Reservations
       .Include(r => r.Services) // Include bảng trung gian
       .FirstOrDefault(r => r.ReservationId == id);

            if (reservation == null)
                return;

            // Xoá tất cả quan hệ nhiều-nhiều trước
            reservation.Services.Clear();

            // Xoá chính nó
            _context.Reservations.Remove(reservation);
        }

       

        public List<Reservation> List()
        {
            return _context.Reservations.ToList();
        }



        public Reservation Update(Reservation model)
        {




            // Cập nhật các thông tin cơ bản
            _context.Reservations.Update(model);
            return model;
        }
        public Service Find(int id, Reservation reservation)
        {
            var service = _context.Services.Find(id);
            if (service != null) reservation.Services.Add(service);
            return service;
        }

        public Reservation FindReservation(int id)
        {
            return _context.Reservations
       .Include(r => r.Services)
       .FirstOrDefault(r => r.ReservationId == id);
        }

        public void ClearService(Reservation reservation)
        {
            reservation.Services.Clear();
        }
        public Account FindStaff(Reservation reservation)
        {
            return _context.Accounts
                .FirstOrDefault(a => a.PersonId == reservation.StaffId);
        }

        public Account FindCustomer(Reservation reservation)
        {
            return _context.Accounts.FirstOrDefault(a => a.PersonId == reservation.CustomerId);
        }
    }
}
