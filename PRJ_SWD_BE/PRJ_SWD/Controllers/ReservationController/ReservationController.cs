using Microsoft.AspNetCore.Mvc;
using PRJ_SWD.Business.Service.ReservationService;
using PRJ_SWD.DAL.DTO;

namespace PRJ_SWD.Controllers.ReservationController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService reservationService;

        public ReservationController(ReservationService reservationService)
        {
            this.reservationService = reservationService;
        }
        [HttpGet("list")]
        public IActionResult List() { 
            var list = reservationService.GetAllReservations();
            return Ok(list);
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] ReservationCreateDto reservation)
        {
            reservationService.AddReservation(reservation);
            return Ok(new { message = "Reservation created successfully" });
        }

        [HttpGet("detail/{id}")]
        public IActionResult Detail(int id)
        {
            var reservaton = reservationService.GetReservationById(id);
            return Ok(reservaton);
        }
    }
}
