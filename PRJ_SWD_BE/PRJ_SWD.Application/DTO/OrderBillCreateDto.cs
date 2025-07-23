using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.Application.DTO
{
    public class OrderBillCreateDto
    {
        public string OrderDate { get; set; } = null!;
        public int CustomerId { get; set; }
        public int TotalAmount { get; set; }
        public int PaymentMethod { get; set; }
        public int ReservationId { get; set; }
        public int ScheduleId { get; set; }
    }

}

