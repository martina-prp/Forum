using System;
using AutoMapper;
using SiteSystem.Data.Repositories;
using SiteSystem.Models;

namespace SiteSystem.Common.Mapping
{
    public class CustomForumResolver : IMemberValueResolver<object, Topic, int, SiteForum>
    {
        private IRepository<SiteForum> forumRepo;

        public CustomForumResolver(IRepository<SiteForum> forumRepo)
        {
            this.forumRepo = forumRepo;
        }

        /*public SiteForum Resolve(int source, Topic destination, SiteForum destMember, ResolutionContext context)
        {
            return forumRepo.Find(source);
        }*/

        public SiteForum Resolve(object source, Topic destination, int sourceMember, SiteForum destMember, ResolutionContext context)
        {
            return forumRepo.Find(sourceMember);
        }
    }
}
