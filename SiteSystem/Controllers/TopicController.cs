using AutoMapper;
using Microsoft.AspNet.Identity;
using SiteSystem.Models;
using SiteSystem.Services.Contracts;
using SiteSystem.ViewModels;
using System.Web.Mvc;

namespace SiteSystem.Controllers
{
    public class TopicController : Controller
    {
        private IForumService forumService;
        private ITopicService topicService;
        private IApplicationUserService userService;

        public TopicController(ITopicService topicService, IApplicationUserService userService, IForumService forumService)
        {
            this.forumService = forumService;
            this.topicService = topicService;
            this.userService = userService;
        }

        // GET: Topic
        /*public ActionResult Index()
        {
            return View();
        }*/

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int id, TopicViewModels topicViewModels)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser dbUser = userService.Find(User.Identity.GetUserId());
                SiteForum dbForum = forumService.Find(id);
                Topic topic = Mapper.Map<Topic>(topicViewModels);
                topic.User = dbUser;
                topic.Forum = dbForum;

                topicService.Add(topic);
            }

            return RedirectToAction("Info", "Forum", new { id = id });
        }
    }
}