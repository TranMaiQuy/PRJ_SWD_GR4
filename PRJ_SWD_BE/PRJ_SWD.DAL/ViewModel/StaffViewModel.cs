using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.DAL.ViewModel
{
    public class StaffViewModel
    {
        public int PersonId { get; set; }

        public string PersonName { get; set; } = null!;

        public int? StaffId { get; set; }

        public string StaffName
        {
            get
            {
                return StaffId switch
                {
                    1 => "Doctor",
                    2 => "Nurse",
                    _ => "Unknown"
                };
            }
        }
    }
}
