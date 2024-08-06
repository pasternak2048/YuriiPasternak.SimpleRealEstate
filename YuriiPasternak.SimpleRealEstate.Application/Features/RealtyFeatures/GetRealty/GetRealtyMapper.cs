using AutoMapper;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.GetRealty
{
    public sealed class GetRealtyMapper : Profile
    {
        public GetRealtyMapper()
        {
            CreateMap<Realty, GetRealtyResponse>().ReverseMap();
        }
    }
}
