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
            CreateMap<Game, GameShowDTO>();
            CreateMap<Game, GameCreateDTO>().ReverseMap();
            CreateMap<GenreDTO, Genre>().ForMember(i => i.Games, opt => opt.Ignore())
                .ForMember(dest => dest.ParentGenre, opt => opt.Ignore());
            CreateMap<PlatformType, PlatformDTO>().ReverseMap().ForMember(i => i.Games, opt => opt.Ignore());
            CreateMap<Game, GameEditDTO>().ReverseMap();
        }

        public static void Register()
        {
            Mapper.Initialize(a => a.AddProfile<AutoMapperConfig>());
        }
    }
}