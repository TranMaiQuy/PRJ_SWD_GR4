using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.DTO;
using PRJ_SWD.DAL.Models;

namespace PRJ_SWD.Business.Service.BlogService
{
    internal interface IBlogService
    {
        Blog AddReservation(Blog reservation);
        Blog DeleteReservation(int id);
        Blog UpdateReservation(Blog blog);
        List<BlogDTO> GetAllReservations();
        Blog GetReservationById(int id);
    }
}
