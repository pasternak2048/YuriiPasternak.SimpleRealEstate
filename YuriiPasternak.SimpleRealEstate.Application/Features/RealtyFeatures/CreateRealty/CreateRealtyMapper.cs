using AutoMapper;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.CreateRealty
{
    public sealed class CreateRealtyMapper : Profile
    {
        public CreateRealtyMapper()
        {
            CreateMap<CreateRealtyRequest, Realty>();

            CreateMap<int, RealtyPlanningType>()
                .ForMember(dest => dest.PlanningTypeId, opts => opts.MapFrom(y => y));

            CreateMap<int, RealtyHeatingType>()
                .ForMember(dest => dest.HeatingTypeId, opts => opts.MapFrom(y => y));

            CreateMap<int, RealtyWallType>()
                .ForMember(dest => dest.WallTypeId, opts => opts.MapFrom(y => y));
        }
    }
}
