using Microsoft.AspNetCore.Mvc;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.Business.Service.OrderBillService;

namespace PRJ_SWD.Controllers
{
    [ApiController]
    [Route("api/OrderBill")]
    public class OrderBillController : ControllerBase
    {
        private readonly IOrderBillService _orderBillService;

        public OrderBillController(IOrderBillService orderBillService)
        {
            _orderBillService = orderBillService;
        }

        // GET: api/OrderBill/list
        [HttpGet("list")]
        public IActionResult List()
        {
            var list = _orderBillService.GetAll();
            return Ok(list);
        }

        // GET: api/OrderBill/detail/{id}
        [HttpGet("detail/{id}")]
        public IActionResult Detail(int id)
        {
            var orderDetail = _orderBillService.GetById(id);
            if (orderDetail == null)
                return NotFound(new { message = $"OrderBill with id {id} not found" });

            return Ok(orderDetail);
        }

        // POST: api/OrderBill/create
        [HttpPost("create")]
        public IActionResult Create([FromBody] OrderBillCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _orderBillService.Create(dto);
            return Ok(new { message = "OrderBill created successfully" });
        }

        // PUT: api/OrderBill/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrderBillUpdateDto dto)
        {
            if (id != dto.OrderId)
                return BadRequest(new { message = "ID mismatch" });

            _orderBillService.Update(dto);
            return Ok(new { message = "OrderBill updated successfully" });
        }

        // DELETE: api/OrderBill/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderBillService.Delete(id);
            return Ok(new { message = "OrderBill deleted successfully" });
        }
    }
}
