using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.Application.ViewModel;
using PRJ_SWD.DAL.Models;


namespace PRJ_SWD.DAL.Repository
{
   public interface IReservationRepository
    {
        void Add(ReservationCreateDto dto);
        void Delete(int id);
        ReservationViewModel GetById(int id);
        List<Reservation> List();
        Reservation Update(int id, ReservationUpdateDto model);
    }
}
