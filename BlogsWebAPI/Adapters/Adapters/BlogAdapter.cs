using BlogsWebAPI.Adapters.Interfaces;
using BlogsWebAPI.Data;
using BlogsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogsWebAPI.Adapters.Adapters
{
    public class BlogAdapter : IBlogAdaper
    {
        public List<Models.BlogViewModel> GetAllBlogs(string userId)
        {
            List<BlogViewModel> model;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Blogs.Where(x => x.UserId == userId && x.isDeleted == false).Select(x => new BlogViewModel()
                    {
                        Description = x.Description,
                        DateCreated = x.DateCreated,
                        BlogId = x.BlogId
                    }).ToList();
            }
            return model;
        }
    }
}