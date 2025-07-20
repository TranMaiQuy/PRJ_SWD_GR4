using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.Application.DTO
{
    public class ServiceCreateDto
    {
        public string ServiceName { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public int Status { get; set; }
        public string Image { get; set; } = null!;
        public string? Duration { get; set; }
        public string? Detail { get; set; }
        public int ManagerId { get; set; }
    }
}
