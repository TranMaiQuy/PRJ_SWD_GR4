using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.Repository;


namespace PRJ_SWD.Business.Service.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> reservationRepository;

        public ReservationService(IRepository<Reservation> reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public Reservation AddReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Reservation DeleteReservation(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAllReservations()
        {
            return reservationRepository.List();
        }

        public Reservation GetReservationById(int id)
        {
            throw new NotImplementedException();
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
