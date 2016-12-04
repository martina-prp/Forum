using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteSystem.Data;
using AutoMapper;

namespace SiteSystem.Controllers
{
    public class BaseController : Controller
    {
        public BaseController() : this(new SiteSystemDbContext())
        {
        }

        public BaseController(SiteSystemDbContext siteSystemDbContext)
        {
            this.Context = siteSystemDbContext;
        }

        protected SiteSystemDbContext Context
        {
            get;
            set;
        }
    }
}