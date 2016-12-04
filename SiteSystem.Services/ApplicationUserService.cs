using SiteSystem.Data;
using SiteSystem.Models;
using SiteSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSystem.Services
{
    public class ApplicationUserService : BaseService<ApplicationUser>, IApplicationUserService
    {
        public ApplicationUserService(ISiteSystemData data)
            :base(data)
        {
        }

    }
}
