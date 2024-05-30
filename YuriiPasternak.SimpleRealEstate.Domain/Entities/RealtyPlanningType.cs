using YuriiPasternak.SimpleRealEstate.Domain.Common;
using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class RealtyPlanningType : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid RealtyId { get; set; }
        public PlanningTypeEnum PlanningTypeId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual Realty Realty { get; set; }
        public virtual PlanningType PlanningType { get; set; }
    }
}
