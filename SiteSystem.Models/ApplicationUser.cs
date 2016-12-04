using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SiteSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Forums = new HashSet<SiteForum>();
            this.Topics = new HashSet<Topic>();
            this.Comments = new HashSet<Comment>();
            this.News = new HashSet<News>();
            this.Groups = new HashSet<Group>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<SiteForum> Forums
        {
            get;
            set;
        }

        public virtual ICollection<Topic> Topics
        {
            get;
            set;
        }

        public virtual ICollection<Comment> Comments
        {
            get;
            set;
        }

        public virtual ICollection<News> News
        {
            get;
            set;
        }

        public virtual ICollection<Group> Groups
        {
            get;
            set;
        }
    }
}
