using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.Application.ViewModel
{
    public class MedicalExaminationViewModel
    {
        public int Meid { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string StaffName { get; set; } = string.Empty;
        public DateOnly ExaminationDate { get; set; }
        public string Symptoms { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public double ExaminationFee { get; set; }
    }

}
