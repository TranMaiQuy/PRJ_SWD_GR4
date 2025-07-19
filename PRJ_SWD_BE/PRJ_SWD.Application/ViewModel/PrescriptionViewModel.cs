using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.Application.ViewModel
{
    public class PrescriptionViewModel
    {
        public int PrescriptionId { get; set; }
    
        public string DoctorName { get; set; }

        public string CustomerName { get; set; }

        public int MedicineName { get; set; }

        public string Dosage { get; set; } = null!;

        public string Note { get; set; } = null!;

        public double TotalCost { get; set; }

    }
}
