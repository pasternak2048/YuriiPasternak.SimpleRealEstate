using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Application.Common.Exceptions;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.UpdateRealty
{
    public class UpdateRealtyHandler : IRequestHandler<UpdateRealtyRequest, Guid>
    {
        private readonly ISimpleRealEstateDbContext _context;
        private readonly ICurrentUserInitializer _currentUserInitializer;
        private readonly IMapper _mapper;

        public UpdateRealtyHandler(ISimpleRealEstateDbContext context, ICurrentUserInitializer currentUserInitializer, IMapper mapper)
        {
            _context = context;
            _currentUserInitializer = currentUserInitializer;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateRealtyRequest request, CancellationToken cancellationToken)
        {
            var realty = await _context.Realties.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (realty == null) {
                throw new NotFoundException($"Realty with Id {request.Id} not found.");
            }

            realty.Description = request.Body.Description;
            realty.RealtyTypeId = request.Body.RealtyTypeId;
            realty.LocationId = request.Body.LocationId;
            realty.Floor = request.Body.Floor;
            realty.IsFirstFloor = request.Body.IsFirstFloor;
            realty.IsLastFloor = request.Body.IsLastFloor;
            realty.FloorCount = request.Body.FloorCount;
            realty.Area = request.Body.Area;
            realty.RoomCount = request.Body.RoomCount;
            realty.BathCount = request.Body.BathCount;
            realty.BuildDate = request.Body.BuildDate;

            _context.Realties.Update(realty);

            try
            {
                
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception exc)
            {
                throw new SaveChangesFailedException($"Data save failed. {exc.Message}");
            }

            return request.Id;
        }
    }
}
