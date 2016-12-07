using SiteSystem.Common.Paging;
using SiteSystem.Models;
using SiteSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteSystem.Wrappers
{
    public class ForumInfoWrapper
    {
        public int ForumId
        {
            get;
            set;
        }
        public string ForumName
        {
            get;
            set;
        }

        public PaginatedList<Topic> ForumTopics
        {
            get;
            set;
        }

        public ForumInfoWrapper(int forumId, string forumName, PaginatedList<Topic> forumTopics)
        {
            ForumId = forumId;
            ForumName = forumName;
            ForumTopics = forumTopics;
        }
    }
}