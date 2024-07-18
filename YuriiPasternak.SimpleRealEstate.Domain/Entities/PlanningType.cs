using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class PlanningType
    {
        public PlanningType()
        {
            RealtyPlanningTypes = new HashSet<RealtyPlanningType>();
        }

        public PlanningTypeEnum Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<RealtyPlanningType> RealtyPlanningTypes { get; set; }
    }
}
