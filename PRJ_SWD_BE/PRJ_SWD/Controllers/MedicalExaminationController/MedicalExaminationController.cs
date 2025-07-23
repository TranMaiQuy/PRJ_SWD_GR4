using Microsoft.AspNetCore.Mvc;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.Business.Service.MedicalExam;

namespace PRJ_SWD.Controllers.MedicalExaminationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalExaminationController : ControllerBase
    {
        private readonly IMedicalExaminationService _service;

        public MedicalExaminationController(IMedicalExaminationService service)
        {
            _service = service;
        }

        [HttpGet("list")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var me = _service.GetById(id);
            if (me == null) return NotFound();
            return Ok(me);
        }

        [HttpPost]
        public IActionResult Create(MedicalExaminationDTO dto)
        {
            _service.Create(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MedicalExaminationDTO dto)
        {
            if (id != dto.Meid) return BadRequest();
            _service.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }

}
