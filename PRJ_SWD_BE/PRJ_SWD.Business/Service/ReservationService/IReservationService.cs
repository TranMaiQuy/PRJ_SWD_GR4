using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using PRJ_SWD.Application.DTO;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.Application.ViewModel;

namespace PRJ_SWD.Business.Service.ReservationService
{
   public interface IReservationService
    {
        void AddReservation(ReservationCreateDto reservation);
       void DeleteReservation(int id);
        void UpdateReservation(ReservationUpdateDto reservation);
        List<ReservationViewModel> GetAllReservations();
        ReservationViewModel GetReservationById(int id);
    }
}
