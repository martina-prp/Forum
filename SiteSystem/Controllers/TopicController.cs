using AutoMapper;
using Microsoft.AspNet.Identity;
using SiteSystem.Models;
using SiteSystem.Services.Contracts;
using SiteSystem.ViewModels;
using SiteSystem.Wrappers;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Info(int id)
        {
            List<CommentViewModels> topicComments = Mapper.Map<List<Comment>, List<CommentViewModels>>(topicService.GetTopicComments(id).ToList());
            TopicViewModels vmTopic = Mapper.Map<TopicViewModels>(topicService.Find(id));
            TopicInfoWrapper topicWrapper = new TopicInfoWrapper(vmTopic, topicComments);

            return View(topicWrapper);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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

            return RedirectToAction("Info", "Forum", new { Area = "", id = id });
        }

        [HttpGet]
        [Authorize]
        public ActionResult Update(int id)
        {
            Topic topicDb = topicService.Find(id);

            return View(Mapper.Map<TopicViewModels>(topicDb));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Update(int id, TopicViewModels topicVm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Update");
            }

            topicService.Update(Mapper.Map<Topic>(topicVm));

            return RedirectToAction("Info", "Forum", new { Area = "", id = topicVm.Forum.Id });
        }

        [Authorize]
        public ActionResult DeleteConfirmation(int id)
        {
            Topic dbTopic = topicService.Find(id);
            if (dbTopic == null)
            {
                return HttpNotFound();
            }

            TopicViewModels topicVm = Mapper.Map<TopicViewModels>(dbTopic);

            return View(topicVm);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var dbTopic = topicService.Find(id);
            if (dbTopic == null)
            {
                return HttpNotFound();
            }

            TopicViewModels topicVm = Mapper.Map<TopicViewModels>(dbTopic);

            topicService.Delete(id);

            return RedirectToAction("Info", "Forum", new { Area = "", id = topicVm.Forum.Id });
        }
    }
}