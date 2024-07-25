using MediatR;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Application.Common.Exceptions;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.DeleteRealty
{
    public class DeleteRealtyHandler : IRequestHandler<DeleteRealtyRequest, Guid>
    {
        private readonly ISimpleRealEstateDbContext _context;
        private readonly ICurrentUserInitializer _currentUserInitializer;

        public DeleteRealtyHandler(ISimpleRealEstateDbContext context, ICurrentUserInitializer currentUserInitializer)
        {
            _context = context;
            _currentUserInitializer = currentUserInitializer;
        }

        public async Task<Guid> Handle(DeleteRealtyRequest request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUserInitializer.UserId;
            var realty = await _context.Realties.FirstOrDefaultAsync(x => x.Id == request.Id && x.CreatedById == currentUserId, cancellationToken);

            if (realty == null) {
                throw new NotFoundException($"Realty with Id {request.Id} not found.");
            }

            _context.Realties.Remove(realty);

            try
            {

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch
            {
                throw new SaveChangesFailedException("Data save failed.");
            }

            return request.Id;
        }
    }
}
