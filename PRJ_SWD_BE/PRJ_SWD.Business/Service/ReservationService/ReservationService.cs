using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.DTO;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.Repository;
using PRJ_SWD.DAL.ViewModel;


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

        public Reservation DeleteReservation(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAllReservations()
        {
            return reservationRepository.List();
        }

        public ReservationViewModel GetReservationById(int id)
        {
            return reservationRepository.GetById(id);
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
