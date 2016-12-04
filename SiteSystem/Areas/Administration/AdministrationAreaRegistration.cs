using System.Web.Mvc;

namespace SiteSystem.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { controller = "Forum", action = "Index", id = UrlParameter.Optional },
                new[] {"SiteSystem.Areas.Administration.Controllers"}
            );
        }
    }
}