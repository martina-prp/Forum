using SiteSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteSystem.Models;
using SiteSystem.Services;
using SiteSystem.Data;

namespace SiteSystem.Services
{
    public class ForumService : BaseService<SiteForum>, IForumService
    {
        public ForumService(ISiteSystemData data)
            :base(data)
        {
        }

        public override IQueryable<SiteForum> GetAll()
        {
            return base.GetAll().OrderByDescending(forum => forum.DateCreated);
        }

        public override void Add(SiteForum entity)
        {
            entity.DateCreated = DateTime.Now;
            base.Add(entity);
            SaveChanges();
        }

        public override void Update(SiteForum entity)
        {
            base.Update(entity);
            SaveChanges();
        }
        public override void Delete(object id)
        {
            base.Delete(id);
            SaveChanges();
        }

        public ICollection<Topic> GetForumTopics(int id)
        {
            return Find(id).ForumTopics;
        }
    }
}
