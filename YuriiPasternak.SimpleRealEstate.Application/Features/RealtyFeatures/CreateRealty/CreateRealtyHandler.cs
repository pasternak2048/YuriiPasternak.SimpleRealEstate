using AutoMapper;
using MediatR;
using YuriiPasternak.SimpleRealEstate.Application.Common.Exceptions;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.CreateRealty
{
    public class CreateRealtyHandler : IRequestHandler<CreateRealtyRequest, Guid>
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

        public async Task<Guid> Handle(CreateRealtyRequest request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUserInitializer.UserId;
            var currentUserRole = _currentUserInitializer.UserRole;

            if(currentUserId == null || currentUserRole == null)
            {
                throw new UnauthorizedAccessException();
            }

            var realty = _mapper.Map<Realty>(request);

            realty.CreatedById = currentUserId.Value;

            realty.CreatedAt = DateTimeOffset.UtcNow;

            await _context.Realties.AddAsync(realty);

            try
            {

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception exc)
            {
                throw new SaveChangesFailedException($"Data save failed. {exc.Message}");
            }

            return realty.Id;
        }
    }
}
