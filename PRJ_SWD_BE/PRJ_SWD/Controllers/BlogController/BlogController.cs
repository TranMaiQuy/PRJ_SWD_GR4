using Microsoft.AspNetCore.Mvc;
using PRJ_SWD.Business.Service.BlogService;
using PRJ_SWD.Business.Service.ReservationService;

namespace PRJ_SWD.Controllers.BlogController
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogService service;
        public BlogController(BlogService service)
        {
            this.service = service;
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            var list = service.GetAllReservations();
            return Ok(list);
        }

        [HttpGet("detail")]
        public IActionResult Detail(int id) {
            var blog = service.GetReservationById(id);
            return Ok(blog);
        }
    }
}
