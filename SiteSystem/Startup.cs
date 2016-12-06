using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Ninject;
using Owin;
using SiteSystem.Data;
using SiteSystem.Models;
using System;
using System.Reflection;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(SiteSystem.Startup))]
namespace SiteSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}
