using System;
using System.Collections.Generic;

namespace PRJ_SWD.DAL.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = null!;

    public int StaffId { get; set; }
    public string StaffName { get; set; } = null!;
    public DateOnly? CreatedDate { get; set; }

    public int Status { get; set; }

    public DateOnly? ReservationDate { get; set; }
   
    public double TotalCost { get; set; }

    public string Note { get; set; } = null!;
    public List<string> ServiceNames { get; set; } = new();

    public virtual ICollection<OrderBill> OrderBills { get; set; } = new List<OrderBill>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
