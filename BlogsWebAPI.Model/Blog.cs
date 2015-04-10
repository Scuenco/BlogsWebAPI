using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsWebAPI.Model
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public bool isDeleted { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
