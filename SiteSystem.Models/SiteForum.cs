using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSystem.Models
{
    public class SiteForum : BaseModel
    {
        public SiteForum()
        {
            this.ForumTopics = new HashSet<Topic>();
        }
        public string ForumName
        {
            get;
            set;
        }

        public virtual ICollection<Topic> ForumTopics
        {
            get;
            set;
        }
    }
}
