using System;
using System.Collections.Generic;

namespace PRJ_SWD.DAL.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int Amount { get; set; }

    public double Currency { get; set; }

    public int Status { get; set; }

    public DateOnly CreateAt { get; set; }

    public int PersonId { get; set; }

    public virtual Account Person { get; set; } = null!;
}
