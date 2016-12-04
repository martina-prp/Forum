using System;

namespace SiteSystem.ViewModels
{
    public class TopicViewModels
    {
        /*public Topic()
        {
            Comments = new List<Comments>();
        }*/
        public int Id
        {
            get;
            set;
        }

        public string TopicName
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

        /*public ICollection<Comment> Comments
        {
            get;
            set;
        }*/
    }
}