using SiteSystem.Models;
using SiteSystem.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace SiteSystem
{
    public static class AutoMapperConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<ApplicationUserViewModels, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForAllOtherMembers(x => x.Ignore());

                config.CreateMap<ApplicationUser, ApplicationUserViewModels>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForAllOtherMembers(x => x.Ignore());

                config.CreateMap<CommentViewModels, Comment>().ReverseMap();

                config.CreateMap<TopicViewModels, Topic>()
                .ForMember(dest => dest.Comments, opt => opt.Ignore());
                //.ForMember(dest => dest.Forum, opt => opt.ResolveUsing<CustomForumResolver, SiteForum>();

                config.CreateMap<Topic, TopicViewModels>();
                //.ForMember(dest => dest.ForumId, opt => opt.MapFrom(src => src.Forum.Id));

                config.CreateMap<ForumViewModels, SiteForum>()
                .ForMember(dest => dest.ForumTopics, opt => opt.Ignore());

                config.CreateMap<SiteForum, ForumViewModels>()
                .ForMember(dest => dest.ForumTopics, opt => opt.Ignore());
            });

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }

    /*class CustomResolver : IValueResolver<SiteForum, ForumViewModels, ICollection<TopicViewModels>>
    {
        public ICollection<TopicViewModels> Resolve(SiteForum source, ForumViewModels destination, ICollection<TopicViewModels> destMember, ResolutionContext context)
        {
            //var result = Mapper.Map<ICollection<Topic>, ICollection<TopicViewModels>>(source.ForumTopics.ToList());
        var result = new List<TopicViewModels>();
        ICollection<Topic> dbTopics = source.ForumTopics.ToList();
        foreach (var topic in dbTopics)
        {
            result.Add(Mapper.Map<TopicViewModels>(topic));
        }

            return result;
        }
    }*/
}
