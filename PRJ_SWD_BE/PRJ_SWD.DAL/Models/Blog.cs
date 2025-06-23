using System;
using System.Collections.Generic;

namespace PRJ_SWD.DAL.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateOnly CreatedDate { get; set; }

    public string Image { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int PersonId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
