using AutoMapper;
using ZedConf.Core.DTO;
using ZedConf.Entities;

namespace ZedConf.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Speaker, SpeakerDTO>()
                .ForMember(dest => dest.Bio, map => map.MapFrom(src => src.Bio))
                .ForMember(dest => dest.Company, map => map.MapFrom(src => src.Company))
                .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.SpeakerID, map => map.MapFrom(src => src.SpeakerID))
                .ForMember(dest => dest.TalkID, map => map.MapFrom(src => src.TalkID))
                .ReverseMap();

            CreateMap<Attendee, AttendeeDTO>()
                .ForMember(dest => dest.TalkID, map => map.MapFrom(src => src.Talk.TalkID))
                .ForMember(dest => dest.Title, map => map.MapFrom(src => src.Talk.Title))
                .ForMember(dest => dest.Abstract, map => map.MapFrom(src => src.Talk.Abstract))
                .ForMember(dest => dest.Room, map => map.MapFrom(src => src.Talk.Room))
                .ReverseMap();

            CreateMap<Talk, TalkDTO>()
                .ForMember(dest => dest.SpeakerID, map => map.MapFrom(src => src.Speaker.SpeakerID))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Speaker.Name))
                .ForMember(dest => dest.Company, map => map.MapFrom(src => src.Speaker.Company))
                .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Speaker.Email))
                .ForMember(dest => dest.Bio, map => map.MapFrom(src => src.Speaker.Bio))
                .ReverseMap();
        }
    }
}
