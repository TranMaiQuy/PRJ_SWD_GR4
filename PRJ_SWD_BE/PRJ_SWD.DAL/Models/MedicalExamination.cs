using System;
using System.Collections.Generic;

namespace PRJ_SWD.DAL.Models;

public partial class MedicalExamination
{
    public int Meid { get; set; }

    public int ReservationId { get; set; }

    public DateOnly ExaminationDate { get; set; }

    public string Symptoms { get; set; } = null!;

    public string Diagnosis { get; set; } = null!;

    public string Notes { get; set; } = null!;

    public double ExaminationFee { get; set; }

    public int StaffId { get; set; }

    public int CustomerId { get; set; }

    public virtual Account Customer { get; set; } = null!;

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual Account Staff { get; set; } = null!;
}
