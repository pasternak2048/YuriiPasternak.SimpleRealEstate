using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class LocationType
    {
        public LocationType() {
            Locations = new HashSet<Location>();
        }
        public LocationTypeEnum Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Location> Locations { get; set; }
    }
}
