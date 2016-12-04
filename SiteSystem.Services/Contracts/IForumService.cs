using SiteSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSystem.Services.Contracts
{
    public interface IForumService : IService<SiteForum>
    {
        IQueryable<SiteForum> GetAll();

        void Add(SiteForum entity);

        ICollection<Topic> GetForumTopics(int id);
    }
}
