using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public virtual Topic Topic
        {
            get;
            set;
        }
    }
}
