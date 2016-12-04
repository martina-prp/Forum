using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSystem.Models
{
    public class News : BaseModel
    {
        public string Title
        {
            get;
            set;
        }
        
        public string Content
        {
            get;
            set;
        }
    }
}
