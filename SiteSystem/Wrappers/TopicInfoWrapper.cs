using SiteSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteSystem.Wrappers
{
    public class TopicInfoWrapper
    {
        //public int TopicId
        //{
        //    get;
        //    set;
        //}
        //public string TopicName
        //{
        //    get;
        //    set;
        //}

        //public string TopicText
        //{
        //    get;
        //    set;
        //}

        public TopicViewModels Topic
        {
            get;
            set;
        }

        public ICollection<CommentViewModels> TopicComments
        {
            get;
            set;
        }

        public TopicInfoWrapper(TopicViewModels topic, ICollection<CommentViewModels> topicComments)
        {
            //TopicId = topicId;
            //TopicName = topicName;
            Topic = topic;
            TopicComments = topicComments;
        }
    }
}