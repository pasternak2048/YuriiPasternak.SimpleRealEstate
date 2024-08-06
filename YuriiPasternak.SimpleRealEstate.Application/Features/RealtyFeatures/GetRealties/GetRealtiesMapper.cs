using AutoMapper;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.GetRealties
{
    public class GetRealtiesMapper : Profile
    {
        public GetRealtiesMapper()
        {
            CreateMap<Realty, GetRealtiesResponse>().ReverseMap();
        }
    }
}
