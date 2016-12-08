using AutoMapper;
using SiteSystem.Common;
using SiteSystem.Common.Paging;
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

        public ActionResult Index(int? page)
        {
            int pageSize = Constants.PageSize;
            List<Topic> dbTopics = topicService.GetAll().Where(topic => topic.User.UserName == User.Identity.Name).ToList();
            List<TopicViewModels> topics = Mapper.Map<List<TopicViewModels>>(dbTopics);
            PaginatedList<TopicViewModels> paginatedTopics = new PaginatedList<TopicViewModels>(topics, (page ?? 0), pageSize);

            return View("Topics", paginatedTopics);
        }

        public ActionResult Comments(int? page)
        {
            int pageSize = Constants.PageSize;
            List<Comment> dbComments = commentService.GetAll().Where(topic => topic.User.UserName == User.Identity.Name).ToList();
            List<CommentViewModels> comments = Mapper.Map<List<CommentViewModels>>(dbComments);
            PaginatedList<CommentViewModels> paginatedComments = new PaginatedList<CommentViewModels>(comments, (page ?? 0), pageSize);

            return View(paginatedComments);
        }

        public ActionResult AjaxTopics(int? page)
        {
            int pageSize = Constants.PageSize;

            List<Topic> dbTopics = topicService.GetAll().Where(topic => topic.User.UserName == User.Identity.Name).ToList();
            List<TopicViewModels> topics = Mapper.Map<List<TopicViewModels>>(dbTopics);
            PaginatedList<TopicViewModels> paginatedTopics = new PaginatedList<TopicViewModels>(topics, (page ?? 0), pageSize);

            return PartialView("_Topics", paginatedTopics);
        }

        public ActionResult AjaxComments(int? page)
        {
            int pageSize = Constants.PageSize;

            List<Comment> dbComments = commentService.GetAll().Where(comment => comment.User.UserName == User.Identity.Name).ToList();
            List<CommentViewModels> comments = Mapper.Map<List<CommentViewModels>>(dbComments);
            PaginatedList<CommentViewModels> paginatedComments = new PaginatedList<CommentViewModels>(comments, (page ?? 0), pageSize);

            return PartialView("_Comments", paginatedComments);
        }
    }
}