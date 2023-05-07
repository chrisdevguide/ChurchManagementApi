using AutoMapper;
using ChurchManagementApi.Dtos;
using ChurchManagementApi.Models;
using ChurchManagementApi.Services.Implementations;

namespace ChurchManagementApi.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<SignUpRequestDto, ChurchUser>()
                .ForMember(x => x.Username, opt => opt.MapFrom(x => x.Email.ToLower()))
                .ForMember(x => x.RegistrationDate, opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<ApiExceptionDto, ApiException>()
                .ReverseMap();

            CreateMap<MemberDto, Member>();
            CreateMap<GroupDto, Group>();
            CreateMap<AutomatedEmailDto, AutomatedEmail>();
            CreateMap<ChurchEventDto, ChurchEvent>();
        }
    }
}
