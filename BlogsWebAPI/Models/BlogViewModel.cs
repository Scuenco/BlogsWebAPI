using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogsWebAPI.Models
{
    public class BlogViewModel
    {
        public int BlogId { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public bool isDeleted { get; set; }
    }
}