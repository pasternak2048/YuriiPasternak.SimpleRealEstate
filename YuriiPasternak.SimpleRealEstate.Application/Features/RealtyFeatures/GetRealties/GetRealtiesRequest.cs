using MediatR;
using Microsoft.AspNetCore.Mvc;
using YuriiPasternak.SimpleRealEstate.Application.Common.Models.Pagination;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.GetRealties
{
    public class GetRealtiesRequest : IRequest<List<GetRealtiesResponse>>
    {
        public UserParams UserParams { get; set; }
    }
}
