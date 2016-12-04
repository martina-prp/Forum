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
    }
}
