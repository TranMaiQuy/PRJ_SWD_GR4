using Microsoft.AspNetCore.Mvc;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.Business.Service.ServiceService;

namespace PRJ_SWD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService serviceService;

        public ServiceController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            return Ok(serviceService.GetAll());
        }

        [HttpGet("detail/{id}")]
        public IActionResult Detail(int id)
        {
            var service = serviceService.GetById(id);
            if (service == null) return NotFound();
            return Ok(service);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] ServiceCreateDto dto)
        {
            serviceService.Create(dto);
            return Ok(new { message = "Service created successfully" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ServiceUpdateDto dto)
        {
            if (id != dto.ServiceId) return BadRequest();
            serviceService.Update(dto);
            return Ok(new { message = "Service updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            serviceService.Delete(id);
            return Ok(new { message = "Service deleted successfully" });
        }
    }
}
