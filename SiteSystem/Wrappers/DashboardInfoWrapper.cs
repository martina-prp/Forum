using SiteSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteSystem.Wrappers
{
    public class DashboardInfoWrapper
    {
        public ICollection<TopicViewModels> Topics
        {
            get;
            set;
        }

        public ICollection<CommentViewModels> Comments
        {
            get;
            set;
        }

        public DashboardInfoWrapper()
        {
            Topics = new List<TopicViewModels>();
            Comments = new List<CommentViewModels>();
        }
        public DashboardInfoWrapper(ICollection<TopicViewModels> topics, ICollection<CommentViewModels> comments)
        {
            Topics = topics;
            Comments = comments;
        }
    }
}