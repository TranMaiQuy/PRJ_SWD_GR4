using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PRJ_SWD.DAL.DTO
{
    public class BlogDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public IFormFile Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PersonId { get; set; }
        public int CategoryId { get; set; }
    }
}
