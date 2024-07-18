using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class HeatingType
    {
        public HeatingType()
        {
            RealtyHeatingTypes = new HashSet<RealtyHeatingType>();
        }

        public HeatingTypeEnum Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<RealtyHeatingType> RealtyHeatingTypes { get; set; }
    }
}
