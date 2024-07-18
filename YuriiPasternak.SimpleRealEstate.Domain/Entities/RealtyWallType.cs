using YuriiPasternak.SimpleRealEstate.Domain.Enums;
using YuriiPasternak.SimpleRealEstate.Domain.Identity;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class RealtyWallType
    {
        public Guid Id { get; set; }
        public Guid RealtyId { get; set; }
        public WallTypeEnum WallTypeId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public DateTimeOffset CreatedAt { get; set; }
        public Guid CreatedById { get; set; }

        public virtual AppUser Creator { get; set; } = new();
        public virtual Realty Realty { get; set; } = new();
        public virtual WallType WallType { get; set; } = new();
    }
}
