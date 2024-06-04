using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class TerritorialObjectType
    {
        public TerritorialObjectType() {
            TerritorialObjects = new HashSet<TerritorialObject>();
        }
        public TerritorialObjectTypeEnum Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<TerritorialObject> TerritorialObjects { get; set; }
    }
}
