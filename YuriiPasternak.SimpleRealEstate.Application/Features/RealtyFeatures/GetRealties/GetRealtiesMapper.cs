using AutoMapper;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.GetRealties
{
    public sealed class GetRealtiesMapper : Profile
    {
        public GetRealtiesMapper()
        {
            CreateMap<Realty, GetRealtiesResponse>().ReverseMap();
        }
    }
}
