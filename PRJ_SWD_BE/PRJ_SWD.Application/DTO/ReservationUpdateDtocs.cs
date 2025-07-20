using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PRJ_SWD.Application.DTO
{
    public class ReservationUpdateDto
    {
        public int ReservationId { get; set; }
        public string? ReservationDate { get; set; }  
        public string Note { get; set; } = null!;
        public int Status { get; set; }
        public int StaffId { get; set; }

        public List<int> ServiceIds { get; set; } = new();
    }
}
