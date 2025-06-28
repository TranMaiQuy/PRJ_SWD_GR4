using System;
using System.Collections.Generic;

namespace PRJ_SWD.DAL.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int CustomerId { get; set; }

    public int StaffId { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public int Status { get; set; }

    public DateOnly? ReservationDate { get; set; }

    public string Note { get; set; } = null!;

    public virtual Account Customer { get; set; } = null!;

    public virtual ICollection<OrderBill> OrderBills { get; set; } = new List<OrderBill>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
