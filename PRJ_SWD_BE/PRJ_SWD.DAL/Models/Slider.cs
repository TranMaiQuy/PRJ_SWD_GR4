using System;
using System.Collections.Generic;

namespace PRJ_SWD.DAL.Models;

public partial class Slider
{
    public int SliderId { get; set; }

    public string Title { get; set; } = null!;

    public string Image { get; set; } = null!;

    public string Backlink { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int PersonId { get; set; }

    public virtual Account Person { get; set; } = null!;
}
