using Microsoft.AspNetCore.Mvc;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.Business.Service.OrderBillService;

namespace PRJ_SWD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderBillController : ControllerBase
    {
        private readonly IOrderBillService _orderBillService;

        public OrderBillController(IOrderBillService orderBillService)
        {
            _orderBillService = orderBillService;
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            return Ok(_orderBillService.GetAll());
        }

        [HttpGet("detail/{id}")]
        public IActionResult Detail(int id)
        {
            var orderDetail = _orderBillService.GetById(id); // Trả về kiểu OrderBillDetailDto
            if (orderDetail == null) return NotFound();
            return Ok(orderDetail);
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] OrderBillCreateDto dto)
        {
            _orderBillService.Create(dto);
            return Ok(new { message = "OrderBill created successfully" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrderBillUpdateDto dto)
        {
            if (id != dto.OrderId) return BadRequest();
            _orderBillService.Update(dto);
            return Ok(new { message = "OrderBill updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderBillService.Delete(id);
            return Ok(new { message = "OrderBill deleted successfully" });
        }
    }
}
