using Microsoft.AspNetCore.Mvc;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.Business.Service.MedicinePrescriptionService;
using PRJ_SWD.Business.Service.MedicineService;
using PRJ_SWD.DAL.Models;

namespace PRJ_SWD.Controllers
{
    [ApiController]
    [Route("api/prescription")]
    public class MedicinePrescriptionController : Controller
    {
        public IMedicinePrescriptionService service;
        public MedicinePrescriptionController(IMedicinePrescriptionService service)
        {
            this.service = service;
        }
        [HttpGet("list")]
        public IActionResult List()
        {
            return Ok(service.GetAllPrescription());
        }

        [HttpGet("detail/{id}")]
        public IActionResult Detail(int id)
        {
            var medicine = service.GetPrescriptionById(id);
            if (medicine == null) return NotFound();
            return Ok(medicine);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] MedicinePrescriptionDto prescription)
        {
            service.AddPrescription(prescription);
            return Ok(new { message = "Prescription created successfully" });
        }

        [HttpPut("edit/{id}")]
        public IActionResult Update(int id, [FromBody] MedicinePrescriptionUpdateDto prescription)
        {
            if (id != prescription.PrescriptionId) return BadRequest();
            service.UpdatePrescription(id, prescription);
            return Ok(new { message = "Prescription updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.DeletePrescription(id);
            return Ok(new { message = "Prescription deleted successfully" });
        }
    }
}
