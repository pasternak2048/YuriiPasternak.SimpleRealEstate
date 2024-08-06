using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;
using YuriiPasternak.SimpleRealEstate.Application.Common.Models.Pagination;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.GetRealties
{
    public class GetRealtiesHandler : IRequestHandler<GetRealtiesRequest, PagedList<GetRealtiesResponse>>
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

        public async Task<PagedList<GetRealtiesResponse>> Handle(GetRealtiesRequest request, CancellationToken cancellationToken)
        {
            var realtiesQueryable = _context.Realties.AsQueryable();

            var realtiesResult = await PagedList<GetRealtiesResponse>
                .CreateAsync(realtiesQueryable.ProjectTo<GetRealtiesResponse>(_mapper.ConfigurationProvider)
                .AsNoTracking(),
                request.UserParams.PageNumber,
                request.UserParams.PageSize);

            return realtiesResult;
        }
    }
}
