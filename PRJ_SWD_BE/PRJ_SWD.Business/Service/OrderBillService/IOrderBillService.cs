using PRJ_SWD.Application.DTO;
using System.Collections.Generic;

namespace PRJ_SWD.Business.Service.OrderBillService
{
    public interface IOrderBillService
    {
        List<OrderBillDto> GetAll();
        OrderBillDetailDto? GetById(int id);
        void Create(OrderBillCreateDto dto);
        void Update(OrderBillUpdateDto dto);
        void Delete(int id);
    }
}
