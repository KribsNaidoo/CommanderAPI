using AutoMapper;
using CommanderAPI.Dtos;
using CommanderAPI.Models;

namespace CommanderAPI.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
            CreateMap<Command, CommandReadDto>()
            .ForMember(dest => dest.Description, act => act.MapFrom(src => src.HowTo));

            CreateMap<CommandCreateDto, Command>();
        }
    }
}
