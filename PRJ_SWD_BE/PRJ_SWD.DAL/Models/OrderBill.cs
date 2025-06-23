using System;
using System.Collections.Generic;

namespace PRJ_SWD.DAL.Models;

public partial class OrderBill
{
    public int OrderId { get; set; }

    public DateOnly OrderDate { get; set; }

    public int CustomerId { get; set; }

    public int TotalAmount { get; set; }

    public int PaymentMethod { get; set; }

    public int ReservationId { get; set; }

    public int ScheduleId { get; set; }

    public virtual Reservation Reservation { get; set; } = null!;

    public virtual Schedule Schedule { get; set; } = null!;

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
