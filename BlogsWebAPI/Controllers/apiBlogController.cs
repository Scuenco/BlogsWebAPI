using BlogsWebAPI.Adapters.Adapters;
using BlogsWebAPI.Adapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using BlogsWebAPI.Models; // for UserIdentity.GetUserId()
namespace BlogsWebAPI.Controllers
{
    public class apiBlogController : ApiController
    {
        private IBlogAdaper _adapter;
        public apiBlogController()
        {
            _adapter = new BlogAdapter();
        }
        public apiBlogController(IBlogAdaper a)
        {
            _adapter = a;
        }
        public IHttpActionResult Get()
        {
            string userId = User.Identity.GetUserId();
            List<BlogViewModel> model = _adapter.GetAllBlogs(userId);
            return Ok(model);
        }
    }
}
