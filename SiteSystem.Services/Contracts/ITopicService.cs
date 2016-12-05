using SiteSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSystem.Services.Contracts
{
    public interface ITopicService : IService<Topic>
    {
        IQueryable<Topic> GetAll();

        void Add(Topic entity);

        void Update(Topic entity);

        void Delete(object id);

        ICollection<Comment> GetTopicComments(int id);
    }
}
