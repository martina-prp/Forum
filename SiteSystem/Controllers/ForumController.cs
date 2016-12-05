using Microsoft.AspNet.Identity;
using SiteSystem.Controllers;
using SiteSystem.Data.Repositories;
using SiteSystem.Models;
using SiteSystem.Services.Contracts;
using SiteSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.Net;
using SiteSystem.Wrappers;

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

        public ActionResult Index()
        {
            List<SiteForum> dbForums = forumService.GetAll().ToList();

            List<ForumViewModels> forums = Mapper.Map<List<SiteForum>, List<ForumViewModels>>(dbForums);
            for (int i = 0; i < dbForums.Count; i++)
            {
                forums[i].ForumTopics = Mapper.Map<List<Topic>, List<TopicViewModels>>(forumService.GetForumTopics(dbForums[i].Id).ToList());
            }

            return View(forums);
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