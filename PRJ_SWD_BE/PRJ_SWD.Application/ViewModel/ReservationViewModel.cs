using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.Application.ViewModel
{
    public class ReservationViewModel
    {
        public int ReservationId { get; set; }
        public string? ReservationDate { get; set; }  // hoặc DateOnly nếu bạn dùng DateOnly
        public string Note { get; set; } = null!;
        public string StaffName { get; set; } = null!;
        public int StaffId { get; set; }

        public int Status { get; set; }
        public string CustomerName { get; set; } = null!;
        public List<ServiceViewModel> Services { get; set; } = new();
    }
}
