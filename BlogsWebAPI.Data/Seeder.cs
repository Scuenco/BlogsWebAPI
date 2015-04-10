using BlogsWebAPI.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations; //need this for AddOrUpdate()

namespace BlogsWebAPI.Data
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext db, bool seedRoles = false, bool seedUsers = false, bool seedBlogs = false)
        {
            if (seedRoles) SeedRoles(db);
            if (seedUsers) SeedUsers(db);
            if (seedBlogs) SeedBlogs(db);
        }
        private static void SeedRoles(ApplicationDbContext db)
        {
            var manager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            //if a User role doesn't exist, create one
            if (!manager.RoleExists("User"))
            {
                manager.Create(new IdentityRole() { Name = "User" });
            }
        }
        private static void SeedUsers(ApplicationDbContext db)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            if (!db.Users.Any(x => x.UserName == "test"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "test",
                    Email = "test@test.com"
                };
                manager.Create(user, "123123");
                manager.AddToRole(user.Id, "User");
            }
            if (!db.Users.Any(x => x.UserName == "sherry"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "sherry",
                    Email = "sherry@test.com"
                };
                manager.Create(user, "123123");
                manager.AddToRole(user.Id, "User");
            }
        }
        private static void SeedBlogs(ApplicationDbContext db)
        {
            string testId = db.Users.FirstOrDefault(x => x.UserName == "test").Id;
            string sherryId = db.Users.FirstOrDefault(x => x.UserName == "sherry").Id;

            db.Blogs.AddOrUpdate(x => x.BlogId,
                new Blog() { BlogId = 1, Description = "Welcome to my blog.", DateCreated = DateTime.Now, UserId = sherryId },
                new Blog() { BlogId = 2, Description = "This is my second blog.", DateCreated = DateTime.Now, UserId = sherryId },
                new Blog() { BlogId = 3, Description = "This is my third blog.", DateCreated = DateTime.Now, UserId = sherryId },
                new Blog() { BlogId = 4, Description = "My friend's blog.", DateCreated = DateTime.Now, UserId = testId },
                new Blog() { BlogId = 5, Description = "My sister's blog.", DateCreated = DateTime.Now, UserId = testId },
                new Blog() { BlogId = 6, Description = "Other blogs.", DateCreated = DateTime.Now, UserId = testId }
                );
        }
    }
}
