using Microsoft.AspNetCore.Mvc;
using PRJ_SWD.Business.Service.ReservationService;

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
        
    }
}
