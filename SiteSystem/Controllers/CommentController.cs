using AutoMapper;
using Microsoft.AspNet.Identity;
using SiteSystem.Models;
using SiteSystem.Services.Contracts;
using SiteSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteSystem.Controllers
{
    public class CommentController : BaseController
    {
        private ICommentService commentService;
        private ITopicService topicService;
        private IApplicationUserService userService;

        public CommentController(ICommentService commentService, ITopicService topicService, IApplicationUserService userService)
        {
            this.commentService = commentService;
            this.topicService = topicService;
            this.userService = userService;
        }

        // GET: Comment
        /*public ActionResult Index()
        {
            return View();
        }*/

        /*[HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }*/

        [HttpPost]
        [Authorize]
        public ActionResult Create(int id, CommentViewModels commentViewModels)
        {
            if (ModelState.IsValid)
            {
                commentViewModels.DateCreated = DateTime.Now;
                ApplicationUser dbUser = userService.Find(User.Identity.GetUserId());
                Topic dbTopic = Mapper.Map<Topic>(topicService.Find(id));
                Comment comment = Mapper.Map<Comment>(commentViewModels);
                comment.User = dbUser;
                comment.Topic = dbTopic;

                commentService.Add(comment);

                commentViewModels = Mapper.Map<CommentViewModels>(comment);
            }

            return PartialView("_Create", commentViewModels);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            Comment commentDb = commentService.Find(id);

            return View(Mapper.Map<CommentViewModels>(commentDb));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, CommentViewModels commentVm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit");
            }

            commentService.Update(Mapper.Map<Comment>(commentVm));

            return RedirectToAction("Info", "Topic", new { id = commentVm.Topic.Id });
        }
    }
}