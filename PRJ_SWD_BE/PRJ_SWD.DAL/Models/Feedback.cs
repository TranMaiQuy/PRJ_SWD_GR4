using System;
using System.Collections.Generic;

namespace PRJ_SWD.DAL.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public string Content { get; set; } = null!;

    public int CustomerId { get; set; }

    public int ServiceId { get; set; }

    public int StarRating { get; set; }

    public string ResponseFeedback { get; set; } = null!;

    public virtual Person Customer { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
