using YuriiPasternak.SimpleRealEstate.Domain.Enums;
using YuriiPasternak.SimpleRealEstate.Domain.Identity;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class RealtyPlanningType
    {
        public Guid Id { get; set; }
        public Guid? RealtyId { get; set; }
        public PlanningTypeEnum? PlanningTypeId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public Guid CreatedById { get; set; }

        public virtual AppUser Creator { get; set; }
        public virtual Realty Realty { get; set; }
        public virtual PlanningType PlanningType { get; set; }
    }
}
