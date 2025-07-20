using Microsoft.AspNetCore.Mvc;
using PRJ_SWD.Business.Service.ServiceService;
using PRJ_SWD.Business.Service.StaffService;

namespace PRJ_SWD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : Controller
    {
        private StaffService service;
        public StaffController(StaffService service) { 
            this.service = service;
        }
        [Route("list")]
        public IActionResult List()
        {
            var list = service.GetAllStaff();
            return Ok(list);
        }
    }
}
