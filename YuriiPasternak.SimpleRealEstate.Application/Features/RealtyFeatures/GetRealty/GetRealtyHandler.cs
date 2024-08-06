using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Application.Common.Exceptions;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.GetRealty
{
    public class GetRealtyHandler : IRequestHandler<GetRealtyRequest, GetRealtyResponse>
    {
        private readonly ISimpleRealEstateDbContext _context;
        private readonly ICurrentUserInitializer _currentUserInitializer;
        private readonly IMapper _mapper;

        public GetRealtyHandler(ISimpleRealEstateDbContext context, ICurrentUserInitializer currentUserInitializer, IMapper mapper)
        {
            _context = context;
            _currentUserInitializer = currentUserInitializer;
            _mapper = mapper;
        }

        public async Task<GetRealtyResponse> Handle(GetRealtyRequest request, CancellationToken cancellationToken)
        {
            var realty = await _context.Realties
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (realty == null)
            {
                throw new NotFoundException($"Realty with Id {request.Id} not found.");
            }

            return _mapper.Map<GetRealtyResponse>(realty);
        }
    }
}
