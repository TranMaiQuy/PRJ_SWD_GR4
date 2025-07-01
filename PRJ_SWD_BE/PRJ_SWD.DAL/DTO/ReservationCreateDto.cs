using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.DAL.DTO
{
   public class ReservationCreateDto
    {
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public DateOnly? ReservationDate { get; set; }
        public string Note { get; set; } = string.Empty;
        public List<int> ServiceIds { get; set; } = new();
    }
}
