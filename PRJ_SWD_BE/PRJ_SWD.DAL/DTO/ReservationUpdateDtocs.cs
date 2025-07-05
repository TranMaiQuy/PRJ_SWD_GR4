using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.ViewModel;

namespace PRJ_SWD.DAL.DTO
{
    public class ReservationUpdateDto
    {
      
        public string? ReservationDate { get; set; }  
        public string Note { get; set; } = null!;
        public int Status { get; set; }
        public int StaffId { get; set; }

        public List<int> ServiceIds { get; set; } = new();
    }
}
