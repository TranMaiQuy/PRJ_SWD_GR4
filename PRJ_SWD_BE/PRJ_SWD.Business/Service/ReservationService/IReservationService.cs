using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Models;

namespace PRJ_SWD.Business.Service.ReservationService
{
   public interface IReservationService
    {
        Reservation AddReservation(Reservation reservation);
        Reservation DeleteReservation(int id);
        Reservation UpdateReservation(Reservation reservation);
        List<Reservation> GetAllReservations();
        Reservation GetReservationById(int id);
    }
}
