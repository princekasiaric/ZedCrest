using AutoMapper;
using ZedConf.Core.DTO;
using ZedConf.Entities;

namespace ZedConf.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Speaker, SpeakerDTO>().ReverseMap();

            CreateMap<Attendee, AttendeeDTO>()
                .ForMember(dest => dest.TalkDTO, map => map.MapFrom(src => src.Talk));

            CreateMap<Talk, TalkDTO>()
                .ForMember(dest => dest.SpeakerDTO, map => map.MapFrom(src => src.Speaker))
                .ForMember(dest => dest.AttendeeDTO, map => map.MapFrom(src => src.Attendees));
        }
    }
}
