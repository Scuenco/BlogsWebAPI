using BlogsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsWebAPI.Adapters.Interfaces
{
    public interface IBlogAdaper
    {
        List<BlogViewModel> GetAllBlogs(string userId);
    }
}
