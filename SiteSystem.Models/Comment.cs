using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSystem.Models
{
    public class Comment : BaseModel
    {
        public string Text
        {
            get;
            set;
        }

        public virtual SiteForum Forum
        {
            get;
            set;
        }

        public virtual Topic Topic
        {
            get;
            set;
        }
    }
}
