using SiteSystem.Models;
using SiteSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteSystem.Data;

namespace SiteSystem.Services
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService(ISiteSystemData data) : base(data)
        {
        }

        public IQueryable<Comment> GetAll()
        {
            return base.GetAll().OrderByDescending(comment => comment.DateCreated);
        }

        public void Add(Comment entity)
        {
            //entity.DateCreated = DateTime.Now;
            base.Add(entity);
            SaveChanges();
        }
    }
}
