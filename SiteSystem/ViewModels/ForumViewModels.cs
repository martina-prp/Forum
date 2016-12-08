using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiteSystem.ViewModels
{
    public class ForumViewModels
    {
        public ForumViewModels()
        {
            ForumTopics = new List<TopicViewModels>();
        }

        public int Id
        {
            get;
            set;
        }

        [Display(Name = "Forum Name")]
        [Required(ErrorMessage = "Forum Name is required!")]
        public string ForumName
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

        public ICollection<TopicViewModels> ForumTopics
        {
            get;
            set;
        }
    }
}