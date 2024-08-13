using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;
using YuriiPasternak.SimpleRealEstate.Application.Common.Models.Pagination;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.GetRealties
{
    public class GetRealtiesHandler : IRequestHandler<GetRealtiesRequest, List<GetRealtiesResponse>>
    {
        private readonly ISimpleRealEstateDbContext _context;
        private readonly ICurrentUserInitializer _currentUserInitializer;
        private readonly IMapper _mapper;

        public GetRealtiesHandler(ISimpleRealEstateDbContext context, ICurrentUserInitializer currentUserInitializer, IMapper mapper)
        {
            _context = context;
            _currentUserInitializer = currentUserInitializer;
            _mapper = mapper;
        }

        public virtual async Task<List<GetRealtiesResponse>> Handle(GetRealtiesRequest request, CancellationToken cancellationToken)
        {
            var realties = await _context.Realties
                .Skip((request.UserParams.PageNumber - 1) * request.UserParams.PageSize)
                .Take(request.UserParams.PageSize)
                .ToListAsync(cancellationToken);

            var realtiesResult = _mapper.Map<List<GetRealtiesResponse>>(realties);

            return realtiesResult;
        }
    }
}
