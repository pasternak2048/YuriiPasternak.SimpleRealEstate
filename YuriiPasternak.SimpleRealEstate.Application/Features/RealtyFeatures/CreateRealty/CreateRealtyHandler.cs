using AutoMapper;
using MediatR;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.CreateRealty
{
    public class CreateRealtyHandler : IRequestHandler<CreateRealtyRequest, CreateRealtyResponse>
    {
        private readonly ISimpleRealEstateDbContext _context;
        private readonly ICurrentUserInitializer _currentUserInitializer;
        private readonly IMapper _mapper;
        

        public CreateRealtyHandler(ISimpleRealEstateDbContext context, ICurrentUserInitializer currentUserInitializer, IMapper mapper)
        {
            _context = context;
            _currentUserInitializer = currentUserInitializer;
            _mapper = mapper;
        }

        public async Task<CreateRealtyResponse> Handle(CreateRealtyRequest request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUserInitializer.UserId;
            var currentUserRole = _currentUserInitializer.UserRole;

            if(currentUserId == null || currentUserRole == null)
            {
                throw new UnauthorizedAccessException();
            }

            var realty = _mapper.Map<Realty>(request);

            realty.LocationId = Guid.Parse("D29D1388-85B1-4BFA-8B83-14241E6700B2"); //Mock location

            realty.CreatedById = currentUserId.Value;

            realty.CreatedAt = DateTimeOffset.UtcNow;

            await _context.Realties.AddAsync(realty);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CreateRealtyResponse>(realty);
        }
    }
}
