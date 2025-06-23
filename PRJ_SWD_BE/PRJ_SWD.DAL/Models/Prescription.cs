using System;
using System.Collections.Generic;

namespace PRJ_SWD.DAL.Models;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int ExaminationId { get; set; }

    public int DoctorId { get; set; }

    public int CustomerId { get; set; }

    public int MedicineId { get; set; }

    public string Dosage { get; set; } = null!;

    public string Note { get; set; } = null!;

    public double TotalCost { get; set; }

    public virtual MedicalExamination Examination { get; set; } = null!;

    public virtual Medicine Medicine { get; set; } = null!;

    public virtual ICollection<OrderBill> Orders { get; set; } = new List<OrderBill>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
