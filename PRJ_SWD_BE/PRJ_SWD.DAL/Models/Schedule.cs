using System;
using System.Collections.Generic;

namespace PRJ_SWD.DAL.Models;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int SlotId { get; set; }

    public int WeekNumber { get; set; }

    public DateOnly Date { get; set; }

    public int StaffId { get; set; }

    public virtual ICollection<OrderBill> OrderBills { get; set; } = new List<OrderBill>();
}
