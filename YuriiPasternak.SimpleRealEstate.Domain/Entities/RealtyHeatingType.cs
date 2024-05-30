using YuriiPasternak.SimpleRealEstate.Domain.Common;
using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class RealtyHeatingType : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid RealtyId { get; set; }
        public HeatingTypeEnum HeatingTypeId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual Realty Realty { get; set; }
        public virtual HeatingType HeatingType { get; set; }
    }
}
