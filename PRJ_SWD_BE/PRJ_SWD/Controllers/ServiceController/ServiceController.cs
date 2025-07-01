using Microsoft.AspNetCore.Mvc;
using PRJ_SWD.Business.Service.ServiceService;

namespace PRJ_SWD.Controllers.ServiceController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : Controller
    {
        private ServiceService service;
        public ServiceController(ServiceService service) { 
            this.service = service;
        }
        [Route("list")]
        public IActionResult List()
        {
            var list = service.GetAllService();
            return Ok(list);
        }
    }
}
