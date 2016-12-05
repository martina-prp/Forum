using SiteSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSystem.Services.Contracts
{
    public interface ICommentService : IService<Comment>
    {
        IQueryable<Comment> GetAll();

        void Add(Comment entity);

        //void Update(Comment entity);

        //void Delete(object id);
    }
}
