using Microsoft.EntityFrameworkCore;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.Business.Service.OrderBillService;
using PRJ_SWD.DAL.Models;

namespace PRJ_SWD.Business.ServiceImplementation
{
    public class OrderBillService : IOrderBillService
    {
        private readonly PrjSwdContext _context;

        public OrderBillService(PrjSwdContext context)
        {
            _context = context;
        }

        public List<OrderBillDto> GetAll()
        {
            return _context.OrderBills.Select(o => new OrderBillDto
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                CustomerId = o.CustomerId,
                TotalAmount = o.TotalAmount,
                PaymentMethod = o.PaymentMethod,
                ReservationId = o.ReservationId,
                ScheduleId = o.ScheduleId
            }).ToList();
        }

        public OrderBillDetailDto? GetById(int id)
        {
            var o = _context.OrderBills
                .Include(o => o.Reservation)
                .Include(o => o.Schedule)
                .Include(o => o.Services)
                .Include(o => o.Prescriptions)
                .FirstOrDefault(x => x.OrderId == id);

            if (o == null) return null;

            return new OrderBillDetailDto
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                CustomerId = o.CustomerId,
                TotalAmount = o.TotalAmount,
                PaymentMethod = o.PaymentMethod,
                ReservationId = o.ReservationId,
                ReservationDate = o.Reservation?.ReservationDate.ToString("yyyy-MM-dd"),
                ScheduleId = o.ScheduleId,
                ScheduleDescription = o.Schedule?.Description,
                Services = o.Services.Select(s => s.Name).ToList(),
                Prescriptions = o.Prescriptions.Select(p => p.Description).ToList()
            };
        }


        public void Create(OrderBillCreateDto dto)
        {
            var entity = new OrderBill
            {
                OrderDate = dto.OrderDate,
                CustomerId = dto.CustomerId,
                TotalAmount = dto.TotalAmount,
                PaymentMethod = dto.PaymentMethod,
                ReservationId = dto.ReservationId,
                ScheduleId = dto.ScheduleId
            };

            _context.OrderBills.Add(entity);
            _context.SaveChanges();
        }

        public void Update(OrderBillUpdateDto dto)
        {
            var entity = _context.OrderBills.Find(dto.OrderId);
            if (entity == null) return;

            entity.OrderDate = dto.OrderDate;
            entity.CustomerId = dto.CustomerId;
            entity.TotalAmount = dto.TotalAmount;
            entity.PaymentMethod = dto.PaymentMethod;
            entity.ReservationId = dto.ReservationId;
            entity.ScheduleId = dto.ScheduleId;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.OrderBills.Find(id);
            if (entity == null) return;

            _context.OrderBills.Remove(entity);
            _context.SaveChanges();
        }
    }
}
