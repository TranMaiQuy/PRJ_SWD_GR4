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

        public void AddReservation(ReservationCreateDto reservation)
        {

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
            return reservationRepository.GetById(id);
        }

        public Reservation UpdateReservation(int id, ReservationUpdateDto reservation)
        {
            var result = reservationRepository.Update(id, reservation);
            unitOfWork.Commit();
            return result;

        }
    }
}
