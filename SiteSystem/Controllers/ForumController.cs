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

        public ActionResult Info(int id)
        {
            List<TopicViewModels> forumTopics = Mapper.Map<List<Topic>, List<TopicViewModels>>(forumService.GetForumTopics(id).ToList());
            string forumName = forumService.Find(id).ForumName;
            ForumInfoWrapper forumWrapper = new ForumInfoWrapper(id, forumName, forumTopics);
           
            return View(forumWrapper);
        }
    }
}