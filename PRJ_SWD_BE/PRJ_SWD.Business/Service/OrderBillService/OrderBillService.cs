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
            var order = _context.OrderBills
                .Include(o => o.Reservation)
                .Include(o => o.Schedule)
                .Include(o => o.Prescriptions)
                .Include(o => o.Services)
                .FirstOrDefault(o => o.OrderId == id);

            if (order == null) return null;

            // Lấy tên khách hàng từ bảng Customer
            var customer = _context.Accounts.FirstOrDefault(c => c.PersonId == order.CustomerId);

            return new OrderBillDetailDto
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                CustomerId = order.CustomerId,
                CustomerName = customer?.PersonName ?? "Unknown",
                TotalAmount = order.TotalAmount,
                PaymentMethod = order.PaymentMethod,
                ReservationId = order.ReservationId,
                ReservationDate = (DateOnly)(order.Reservation?.ReservationDate),
                ScheduleId = order.ScheduleId,
                ScheduleDescription = $"Slot: {order.Schedule.SlotId}, Date: {order.Schedule.Date}",

                Prescriptions = order.Prescriptions.Select(p =>
                    $"Medicine: {p.Medicine.Name}, Dosage: {p.Dosage}, Note: {p.Note}"
                ).ToList(),

                Services = order.Services.Select(s => s.ServiceName).ToList()
            };
        }





        public void Create(OrderBillCreateDto dto)
        {
            var order = new OrderBill
            {
                OrderDate = DateOnly.Parse(dto.OrderDate),
                CustomerId = dto.CustomerId,
                TotalAmount = dto.TotalAmount,
                PaymentMethod = dto.PaymentMethod,
                ReservationId = dto.ReservationId,
                ScheduleId = dto.ScheduleId
            };


            _context.OrderBills.Add(order);
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
