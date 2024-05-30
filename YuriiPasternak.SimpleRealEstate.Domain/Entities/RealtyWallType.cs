using YuriiPasternak.SimpleRealEstate.Domain.Common;
using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class RealtyWallType : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid RealtyId { get; set; }
        public WallTypeEnum WallTypeId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual Realty Realty { get; set; }
        public virtual WallType WallType { get; set; }
    }
}
