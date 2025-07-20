using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PRJ_SWD.DAL.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public double Price { get; set; }

    public string Description { get; set; } = null!;

    public int Status { get; set; }

    public string Image { get; set; } = null!;

    public string? Duration { get; set; }

    public string? Detail { get; set; }

    public int ManagerId { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Account Manager { get; set; } = null!;

    public virtual ICollection<OrderBill> Orders { get; set; } = new List<OrderBill>();

    public virtual ICollection<Account> People { get; set; } = new List<Account>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    [JsonIgnore]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
