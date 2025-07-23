using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.Application.DTO
{
    public class MedicalExaminationDTO
    {
        public int Meid { get; set; }
        public int ReservationId { get; set; }
        public DateOnly ExaminationDate { get; set; }
        public string Symptoms { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public double ExaminationFee { get; set; }
        public int StaffId { get; set; }
        public int CustomerId { get; set; }
    }
}
