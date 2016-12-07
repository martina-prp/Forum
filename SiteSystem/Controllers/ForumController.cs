using SiteSystem.Models;
using SiteSystem.Services.Contracts;
using SiteSystem.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SiteSystem.Wrappers;
using SiteSystem.Common.Paging;
using SiteSystem.Common;

namespace SiteSystem.Controllers
{
    public class ForumController : BaseController
    {
        private IForumService forumService;
        private IApplicationUserService userService;

        public ForumController(IForumService forumService, IApplicationUserService userService)
        {
            this.forumService = forumService;
            this.userService = userService;
        }

        public ActionResult Index(int? page)
        {
            int pageSize = Constants.PageSize;
            IQueryable<SiteForum> dbForums = forumService.GetAll();
            PaginatedList<SiteForum> dbForumPageList = new PaginatedList<SiteForum>(dbForums, 0, pageSize);

            return View(dbForumPageList);
        }

        public ActionResult AjaxIndex(int? page)
        {
            int pageSize = Constants.PageSize;
            IQueryable<SiteForum> dbForums = forumService.GetAll();
            PaginatedList<SiteForum> dbForumPageList = new PaginatedList<SiteForum>(dbForums, (page ?? 0), pageSize);

            return PartialView("_Index", dbForumPageList);
        }

        public ActionResult Info(int id, int? page)
        {
            int pageSize = Constants.PageSize;
            ICollection<Topic> dbForumTopics = forumService.GetForumTopics(id);
            string forumName = forumService.Find(id).ForumName;
            PaginatedList<Topic> dbTopicPageList = new PaginatedList<Topic>(dbForumTopics.AsQueryable(), 0, pageSize);
            ForumInfoWrapper forumWrapper = new ForumInfoWrapper(id, forumName, dbTopicPageList);
           
            return View(forumWrapper);
        }

        public ActionResult AjaxInfo(int id, int? page)
        {
            int pageSize = Constants.PageSize;
            ICollection<Topic> dbForumTopics = forumService.GetForumTopics(id);
            string forumName = forumService.Find(id).ForumName;
            PaginatedList<Topic> dbTopicPageList = new PaginatedList<Topic>(dbForumTopics.AsQueryable(), (page ?? 0), pageSize);
            ForumInfoWrapper forumWrapper = new ForumInfoWrapper(id, forumName, dbTopicPageList);

            return PartialView("_Info", forumWrapper);
        }
    }
}