﻿using SiteSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteSystem.Models;
using SiteSystem.Data;

namespace SiteSystem.Services
{
    public class TopicService : BaseService<Topic>, ITopicService
    {
        public TopicService(ISiteSystemData data)
            :base(data)
        {
        }

        public override IQueryable<Topic> GetAll()
        {
            return base.GetAll().OrderByDescending(topic => topic.DateCreated);
        }

        public override void Add(Topic entity)
        {
            entity.DateCreated = DateTime.Now;
            base.Add(entity);
            SaveChanges();
        }

        public override void Update(Topic entity)
        {
            base.Update(entity);
            SaveChanges();
        }
        public override void Delete(object id)
        {
            base.Delete(id);
            SaveChanges();
        }

        public ICollection<Comment> GetTopicComments(int id)
        {
            return Find(id).Comments;
        }
    }
}
