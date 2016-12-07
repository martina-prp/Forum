using SiteSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SiteSystem.ViewModels
{
    public class TopicViewModels
    {
        public TopicViewModels()
        {
            Comments = new List<Comment>();
        }
        public int Id
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Topic Name is required!")]
        public string TopicName
        {
            get;
            set;
        }

        [AllowHtml]
        [Required(ErrorMessage = "Topic Text is required!")]
        public string TopicText
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

        public ForumViewModels Forum
        {
            get;
            set;
        }

        public ICollection<Comment> Comments
        {
            get;
            set;
        }
    }
}