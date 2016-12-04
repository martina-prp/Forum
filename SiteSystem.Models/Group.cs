using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSystem.Models
{
    public class Group : BaseModel
    {
        public string GroupName
        {
            get;
            set;
        }

        public string Info
        {
            get;
            set;
        }
    }
}
