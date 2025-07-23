using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.Application.DTO
{
    public class MedicinePrescriptionUpdateDto 
    {
        public int PrescriptionId { get; set; }
        public string Dosage { get; set; } = null!;

        public string Note { get; set; } = null!;

        public double TotalCost { get; set; }
    }
}
