using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.DTO;
using PRJ_SWD.DAL.Models;

namespace PRJ_SWD.Business.Service.ReservationService
{
   public interface IReservationService
    {
        void AddReservation(ReservationCreateDto reservation);
        Reservation DeleteReservation(int id);
        Reservation UpdateReservation(Reservation reservation);
        List<Reservation> GetAllReservations();
        Reservation GetReservationById(int id);
    }
}
