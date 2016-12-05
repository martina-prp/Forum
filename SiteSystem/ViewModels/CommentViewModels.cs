using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteSystem.ViewModels
{
    public class CommentViewModels
    {
        public int Id
        {
            get;
            set;
        }

        public DateTime? DateCreated
        {
            get;
            set;
        }

        public ApplicationUserViewModels User
        {
            get;
            set;
        }

        [AllowHtml]
        public string Text
        {
            get;
            set;
        }

        public TopicViewModels Topic
        {
            get;
            set;
        }
    }
}