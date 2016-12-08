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
using SiteSystem.Common.Caching;

namespace SiteSystem.Controllers
{
    public class ForumController : BaseController
    {
        private IForumService forumService;
        private IApplicationUserService userService;
        private ICacheService cacheService;

        public ForumController(IForumService forumService, IApplicationUserService userService, ICacheService cacheService)
        {
            this.forumService = forumService;
            this.userService = userService;
            this.cacheService = cacheService;
        }

        public ActionResult Index(int? page)
        {
            int pageSize = Constants.PageSize;

            List<SiteForum> dbForums = cacheService.Get<List<SiteForum>>("allForums", () =>
            {
                return forumService.GetAll().ToList();
            }, 60);

            List<ForumViewModels> forums = Mapper.Map<List<ForumViewModels>>(dbForums);
            PaginatedList<ForumViewModels> forumPageList = new PaginatedList<ForumViewModels>(forums, (page ?? 0), pageSize);

            return View(forumPageList);
        }

        public ActionResult AjaxIndex(int? page)
        {
            int pageSize = Constants.PageSize;

            List<SiteForum> dbForums = cacheService.Get<List<SiteForum>>("allForums", () =>
            {
                return forumService.GetAll().ToList();
            }, 60);

            List<ForumViewModels> forums = Mapper.Map<List<ForumViewModels>>(dbForums);
            PaginatedList<ForumViewModels> forumPageList = new PaginatedList<ForumViewModels>(forums, (page ?? 0), pageSize);

            return PartialView("_Index", forumPageList);
        }

        public ActionResult Info(int id, int? page)
        {
            int pageSize = Constants.PageSize;

            List<Topic> dbForumTopics = cacheService.Get<List<Topic>>("forumTopics", () =>
            {
                return forumService.GetForumTopics(id).ToList();
            }, 60);

            string forumName = forumService.Find(id).ForumName;
            List<TopicViewModels> topics = Mapper.Map<List<TopicViewModels>>(dbForumTopics);
            PaginatedList<TopicViewModels> topicPageList = new PaginatedList<TopicViewModels>(topics, (page ?? 0), pageSize);
            ForumInfoWrapper forumWrapper = new ForumInfoWrapper(id, forumName, topicPageList);
           
            return View(forumWrapper);
        }

        public ActionResult AjaxInfo(int id, int? page)
        {
            int pageSize = Constants.PageSize;

            List<Topic> dbForumTopics = cacheService.Get<List<Topic>>("forumTopics", () =>
            {
                return forumService.GetForumTopics(id).ToList();
            }, 60);

            string forumName = forumService.Find(id).ForumName;
            List<TopicViewModels> topics = Mapper.Map<List<TopicViewModels>>(dbForumTopics);
            PaginatedList<TopicViewModels> topicPageList = new PaginatedList<TopicViewModels>(topics, (page ?? 0), pageSize);
            ForumInfoWrapper forumWrapper = new ForumInfoWrapper(id, forumName, topicPageList);

            return PartialView("_Info", forumWrapper);
        }
    }
}