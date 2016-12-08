using SiteSystem.Common.Paging;
using SiteSystem.Models;
using System.Collections.Generic;

namespace SiteSystem.Wrappers
{
    public class DashboardInfoWrapper
    {
        public PaginatedList<Topic> Topics
        {
            get;
            set;
        }

        public PaginatedList<Comment> Comments
        {
            get;
            set;
        }

        public DashboardInfoWrapper()
        {
            Topics = new PaginatedList<Topic>();
            Comments = new PaginatedList<Comment>();
        }
        public DashboardInfoWrapper(PaginatedList<Topic > topics, PaginatedList<Comment > comments)
        {
            Topics = topics;
            Comments = comments;
        }
    }
}