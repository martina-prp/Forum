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
            List<SiteForum> dbForums = forumService.GetAll().ToList();
            List<ForumViewModels> forums = Mapper.Map<List<ForumViewModels>>(dbForums);
            PaginatedList<ForumViewModels> forumPageList = new PaginatedList<ForumViewModels>(forums, (page ?? 0), pageSize);

            return View(forumPageList);
        }

        public ActionResult AjaxIndex(int? page)
        {
            int pageSize = Constants.PageSize;
            List<SiteForum> dbForums = forumService.GetAll().ToList();
            List<ForumViewModels> forums = Mapper.Map<List<ForumViewModels>>(dbForums);
            PaginatedList<ForumViewModels> forumPageList = new PaginatedList<ForumViewModels>(forums, (page ?? 0), pageSize);

            return PartialView("_Index", forumPageList);
        }

        public ActionResult Info(int id, int? page)
        {
            int pageSize = Constants.PageSize;
            ICollection<Topic> dbForumTopics = forumService.GetForumTopics(id);
            string forumName = forumService.Find(id).ForumName;
            List<TopicViewModels> topics = Mapper.Map<List<TopicViewModels>>(dbForumTopics);
            PaginatedList<TopicViewModels> topicPageList = new PaginatedList<TopicViewModels>(topics, (page ?? 0), pageSize);
            ForumInfoWrapper forumWrapper = new ForumInfoWrapper(id, forumName, topicPageList);
           
            return View(forumWrapper);
        }

        public ActionResult AjaxInfo(int id, int? page)
        {
            int pageSize = Constants.PageSize;
            ICollection<Topic> dbForumTopics = forumService.GetForumTopics(id);
            string forumName = forumService.Find(id).ForumName;
            List<TopicViewModels> topics = Mapper.Map<List<TopicViewModels>>(dbForumTopics);
            PaginatedList<TopicViewModels> topicPageList = new PaginatedList<TopicViewModels>(topics, (page ?? 0), pageSize);
            ForumInfoWrapper forumWrapper = new ForumInfoWrapper(id, forumName, topicPageList);

            return PartialView("_Info", forumWrapper);
        }
    }
}