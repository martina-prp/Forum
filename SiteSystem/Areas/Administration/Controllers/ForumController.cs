using AutoMapper;
using SiteSystem.ViewModels;
using SiteSystem.Controllers;
using SiteSystem.Data.Repositories;
using SiteSystem.Models;
using SiteSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace SiteSystem.Areas.Administration.Controllers
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ForumViewModels forumViewModels)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser dbUser = userService.Find(User.Identity.GetUserId());
                SiteForum forum = Mapper.Map<SiteForum>(forumViewModels);
                forum.User = dbUser;

                forumService.Add(forum);
            }

            return RedirectToAction("Index", "Forum", new { Area = "", all = "All"});
        }

        public ActionResult DeleteConfirmation(int id)
        {
            var dbForum = forumService.Find(id);
            if (dbForum == null)
            {
                return HttpNotFound();
            }

            ForumViewModels forumVm = Mapper.Map<ForumViewModels>(dbForum);

            return View(forumVm);
        }

        public ActionResult Delete(int id)
        {
            var dbForum = forumService.Find(id);
            if (dbForum == null)
            {
                return HttpNotFound();
            }

            ForumViewModels forumVm = Mapper.Map<ForumViewModels>(dbForum);

            forumService.Delete(id);

            return RedirectToAction("Index", "Forum", new { Area = "", all = "All"});
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            SiteForum forumDb = forumService.Find(id);

            return View(Mapper.Map<ForumViewModels>(forumDb));
        }

        [HttpPost]
        public ActionResult Update(int id, ForumViewModels forumVm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Update");
            }

            forumService.Update(Mapper.Map<SiteForum>(forumVm));

            return RedirectToAction("Index", "Forum", new { Area = "", all = "All" });
        }
    }
}