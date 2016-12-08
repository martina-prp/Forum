using AutoMapper;
using SiteSystem.Common;
using SiteSystem.Common.Caching;
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
        private ICacheService cacheService;

        public DashboardController(ITopicService topicService, ICommentService commentService, ICacheService cacheService)
        {
            this.topicService = topicService;
            this.commentService = commentService;
            this.cacheService = cacheService;
        }

        public ActionResult Index(int? page)
        {
            int pageSize = Constants.PageSize;
           
            List<Topic> dbTopics = cacheService.Get<List<Topic>>("myTopics", () =>
            {
                return topicService.GetAll().Where(topic => topic.User.UserName == User.Identity.Name).ToList();
            }, 60);

            List<TopicViewModels> topics = Mapper.Map<List<TopicViewModels>>(dbTopics);
            PaginatedList<TopicViewModels> paginatedTopics = new PaginatedList<TopicViewModels>(topics, (page ?? 0), pageSize);

            return View("Topics", paginatedTopics);
        }

        public ActionResult Comments(int? page)
        {
            int pageSize = Constants.PageSize;
            
            List<Comment> dbComments = cacheService.Get<List<Comment>>("myComments", () =>
            {
                return commentService.GetAll().Where(topic => topic.User.UserName == User.Identity.Name).ToList();
            }, 60);

            List<CommentViewModels> comments = Mapper.Map<List<CommentViewModels>>(dbComments);
            PaginatedList<CommentViewModels> paginatedComments = new PaginatedList<CommentViewModels>(comments, (page ?? 0), pageSize);

            return View(paginatedComments);
        }

        public ActionResult AjaxTopics(int? page)
        {
            int pageSize = Constants.PageSize;

            List<Topic> dbTopics = cacheService.Get<List<Topic>>("myTopics", () =>
            {
                return topicService.GetAll().Where(topic => topic.User.UserName == User.Identity.Name).ToList();
            }, 60);

            List<TopicViewModels> topics = Mapper.Map<List<TopicViewModels>>(dbTopics);
            PaginatedList<TopicViewModels> paginatedTopics = new PaginatedList<TopicViewModels>(topics, (page ?? 0), pageSize);

            return PartialView("_Topics", paginatedTopics);
        }

        public ActionResult AjaxComments(int? page)
        {
            int pageSize = Constants.PageSize;

            List<Comment> dbComments = cacheService.Get<List<Comment>>("myComments", () =>
            {
                return commentService.GetAll().Where(topic => topic.User.UserName == User.Identity.Name).ToList();
            }, 60);

            List<CommentViewModels> comments = Mapper.Map<List<CommentViewModels>>(dbComments);
            PaginatedList<CommentViewModels> paginatedComments = new PaginatedList<CommentViewModels>(comments, (page ?? 0), pageSize);

            return PartialView("_Comments", paginatedComments);
        }
    }
}