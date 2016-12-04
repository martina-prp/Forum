using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSystem.Models
{
    public class BaseModel
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

        public virtual ApplicationUser User
        {
            get;
            set;
        }
    }
}
