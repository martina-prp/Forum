using SiteSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSystem.Services.Contracts
{
    public interface IApplicationUserService : IService<ApplicationUser>
    {
        IQueryable<ApplicationUser> GetAll();

        //ApplicationUser Find(string name);
    }
}
