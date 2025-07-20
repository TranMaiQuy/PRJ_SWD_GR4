using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.Application.DTO
{
    public class OrderBillUpdateDto
    {
        public int OrderId { get; set; }
        public DateOnly OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int TotalAmount { get; set; }
        public int PaymentMethod { get; set; }
        public int ReservationId { get; set; }
        public int ScheduleId { get; set; }
    }
}
