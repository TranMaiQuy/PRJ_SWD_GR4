﻿using Microsoft.AspNetCore.Mvc;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.Business.Service.MedicineService;
using PRJ_SWD.Business.Service.ServiceService;
using PRJ_SWD.DAL.Models;

namespace PRJ_SWD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicineController : Controller
    {
        public IMedicineService medicineService;

        public MedicineController(IMedicineService medicineService)
        {
           this.medicineService = medicineService;
        }
        [HttpGet("list")]
        public IActionResult List()
        {
            return Ok(medicineService.GetAllMedicine());
        }

        [HttpGet("detail/{id}")]
        public IActionResult Detail(int id)
        {
            var medicine = medicineService.GetMedicineById(id);
            if (medicine == null) return NotFound();
            return Ok(medicine);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Medicine medicine)
        {
            medicineService.AddMedicine(medicine);
            return Ok(new { message = "Medicine created successfully" });
        }

        [HttpPut("edit/{id}")]
        public IActionResult Update(int id, [FromBody] Medicine medicine)
        {
            if (id != medicine.MedicineId) return BadRequest();
            medicineService.UpdateMedicine(medicine);
            return Ok(new { message = "Medicine updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            medicineService.DeleteMedicine(id);
            return Ok(new { message = "Medicine deleted successfully" });
        }
    }
}
