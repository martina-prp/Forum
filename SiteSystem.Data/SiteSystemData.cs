using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteSystem.Data.Repositories;
using SiteSystem.Models;

namespace SiteSystem.Data
{
    public class SiteSystemData : ISiteSystemData
    {
        private SiteSystemDbContext context;
        private Dictionary<Type, object> repositories;

        public SiteSystemData() : this(new SiteSystemDbContext())
        {
        }

        public SiteSystemData(SiteSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<SiteForum> Forums
        {
            get
            {
                return this.GetRepository<SiteForum>();
            }
        }

        public IRepository<Group> Groups
        {
            get
            {
                return this.GetRepository<Group>();
            }
        }

        public IRepository<News> News
        {
            get
            {
                return this.GetRepository<News>();
            }
        }

        public IRepository<Topic> Topics
        {
            get
            {
                return this.GetRepository<Topic>();
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
