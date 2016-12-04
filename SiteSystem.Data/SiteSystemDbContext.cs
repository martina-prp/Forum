using Microsoft.AspNet.Identity.EntityFramework;
using SiteSystem.Models;
using System.Data.Entity;

namespace SiteSystem.Data
{
    public class SiteSystemDbContext : IdentityDbContext
    {
        public SiteSystemDbContext() : base("SiteSystem")
        {
        }

        public IDbSet<ApplicationUser> Users
        {
            get;
            set;
        }

        public IDbSet<SiteForum> Forums
        {
            get;
            set;
        }

        public IDbSet<Topic> Topics
        {
            get;
            set;
        }

        public IDbSet<Comment> Comments
        {
            get;
            set;
        }

        public IDbSet<News> News
        {
            get;
            set;
        }

        public IDbSet<Group> Groups
        {
            get;
            set;
        }

        public static SiteSystemDbContext Create()
        {
            return new SiteSystemDbContext();
        }
    }
}