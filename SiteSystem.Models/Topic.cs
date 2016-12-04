using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSystem.Models
{
    public class Topic : BaseModel
    {
        public Topic()
        {
            Comments = new HashSet<Comment>();
        }
        public string TopicName
        {
            get;
            set;
        }

        public virtual SiteForum Forum
        {
            get;
            set;
        }

        public virtual ICollection<Comment> Comments
        {
            get;
            set;
        }
    }
}
