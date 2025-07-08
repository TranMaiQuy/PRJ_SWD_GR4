using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.Application.ViewModel
{
    public class BlogViewModel
    {
        public int BlogId { get; set; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public DateOnly CreatedDate { get; set; }

        public string Image { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? PersonName { get; set; }

        public string? CategoryName { get; set; }
    }
}