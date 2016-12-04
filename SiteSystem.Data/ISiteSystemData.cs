using SiteSystem.Data.Repositories;
using SiteSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSystem.Data
{
    public interface ISiteSystemData
    {
        IRepository<ApplicationUser> Users
        {
            get;
        }

        IRepository<SiteForum> Forums
        {
            get;
        }

        IRepository<Topic> Topics
        {
            get;
        }

        IRepository<Comment> Comments
        {
            get;
        }

        IRepository<News> News
        {
            get;
        }
        IRepository<Group> Groups
        {
            get;
        }

        IRepository<T> GetRepository<T>() where T : class;
    }
}
