using AutoMapper;
using GameStore.Core.Entity;
using GameStore.Services.DTO;

namespace GameStore.Web.Infrastructure
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Comment, CommentDTO>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<PlatformType, PlatformDTO>();
            CreateMap<Game, GameDTO>();
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<PlatformType, PlatformDTO>().ReverseMap();
            CreateMap<Game, GameDTO>().ReverseMap();
        }

        public static void Register()
        {
            Mapper.Initialize(a => a.AddProfile<AutoMapperConfig>());
        }
    }
}