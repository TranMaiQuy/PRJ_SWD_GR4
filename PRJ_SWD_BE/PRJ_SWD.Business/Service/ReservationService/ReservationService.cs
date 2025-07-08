using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.Repository;
using PRJ_SWD.Application.ViewModel;


namespace PRJ_SWD.Business.Service.ReservationService
{
    public class ReservationService : IReservationService
    {
       public  ReservationRepository reservationRepository;
       public IUnitOfWork unitOfWork;
       public ReservationService(ReservationRepository reservationRepository, IUnitOfWork unitOfWork)
        {
            this.reservationRepository = reservationRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddReservation(ReservationCreateDto dto)
        {
            var reservation = new Reservation
            {
                CustomerId = dto.CustomerId,
                StaffId = dto.StaffId,
                CreatedDate = DateOnly.FromDateTime(DateTime.Now),
                Status = 0,
                ReservationDate = dto.ReservationDate,
                Note = dto.Note,
            };
            for (int i = 0; i < dto.ServiceIds.Count; i++)
            {
                var service = reservationRepository.Find(dto.ServiceIds[i],reservation);
                
            }

            reservationRepository.Add(reservation);
           unitOfWork.Commit();
        }

        public void DeleteReservation(int id)
        {
            reservationRepository.Delete(id);
            unitOfWork.Commit();
        }

        public List<Reservation> GetAllReservations()
        {
            return reservationRepository.List();
        }

        public ReservationViewModel GetReservationById(int id)
        {
            var reservation = reservationRepository.FindReservation(id);

            if (reservation == null)
                return null;

            // Tìm nhân viên (Staff) có RoleId = 2 và StaffId khớp với CustomerId trong Reservation
            var staff = reservationRepository.FindStaff(reservation);
            var customer = reservationRepository.FindCustomer(reservation);

            var result = new ReservationViewModel
            {
                ReservationId = reservation.ReservationId,
                ReservationDate = reservation.ReservationDate?.ToString("yyyy-MM-dd"),
                Note = reservation.Note,
                Status = reservation.Status,
                StaffId = reservation.StaffId,
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

        public Reservation UpdateReservation(int id, ReservationUpdateDto model)
        {
            var reservation = reservationRepository.FindReservation(id);
            reservation.Note = model.Note;
            reservation.ReservationDate = DateOnly.Parse(model.ReservationDate);
            reservation.Status = model.Status;
            reservation.StaffId = model.StaffId;
            reservationRepository.ClearService(reservation);// xóa toàn bộ service cũ


            for (int i = 0; i < model.ServiceIds.Count; i++)
            {
                reservationRepository.Find(model.ServiceIds[i], reservation);
            }
            var result = reservationRepository.Update( reservation);
            unitOfWork.Commit();
            return result;

        }
    }
}
