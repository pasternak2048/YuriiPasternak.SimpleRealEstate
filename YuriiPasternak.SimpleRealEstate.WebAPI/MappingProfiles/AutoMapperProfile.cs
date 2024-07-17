using AutoMapper;
using YuriiPasternak.SimpleRealEstate.Domain.Identity;
using YuriiPasternak.SimpleRealEstate.WebAPI.Contracts;

namespace YuriiPasternak.SimpleRealEstate.WebAPI.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AuthenticationResponse, AppUser>().ReverseMap();
            CreateMap<RegisterRequest, AppUser>().ReverseMap();
            CreateMap<LoginRequest, AppUser>().ReverseMap();
        }
    }
}
