using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.Application.DTO
{
    public class MedicinePrescriptionDto
    {
        public int ExaminationId { get; set; }

        public int DoctorId { get; set; }

        public int CustomerId { get; set; }

        public int MedicineId { get; set; }

        public string Dosage { get; set; } = null!;

        public string Note { get; set; } = null!;

        public double TotalCost { get; set; }
    }
}
