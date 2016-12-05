using AutoMapper;
using SiteSystem.Controllers;
using SiteSystem.Models;
using SiteSystem.Services.Contracts;
using SiteSystem.ViewModels;
using SiteSystem.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteSystem.Controllers
{
    public class DashboardController : BaseController
    {
        private ITopicService topicService;
        private ICommentService commentService;

        public DashboardController(ITopicService topicService, ICommentService commentService)
        {
            this.topicService = topicService;
            this.commentService = commentService;
        }

        // GET: Dashboard/Dashboard
        public ActionResult Index()
        {
            List<Topic> dbTopics = topicService.GetAll().Where(topic => topic.User.UserName == User.Identity.Name).ToList();
            List<Comment> dbComments = commentService.GetAll().Where(comment => comment.User.UserName == User.Identity.Name).ToList();
            DashboardInfoWrapper dashboardWrapper = new DashboardInfoWrapper(Mapper.Map<List<TopicViewModels>>(dbTopics), Mapper.Map<List<CommentViewModels>>(dbComments));

            return View(dashboardWrapper);
        }
    }
}