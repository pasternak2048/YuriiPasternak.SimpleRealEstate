using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class Location
    {
        public Location() {
            Realties = new HashSet<Realty>();
        }

        public Guid Id { get; set; }
        public LocationTypeEnum LocationTypeId { get; set; }
        public string? Region { get; set; }
        public string? District { get; set; }
        public string? Community { get; set; }
        public string? Locality { get; set; }
        public string? LocalityDistrict { get; set; }
        public string? Street { get; set; }
        public int? BuildingNumber { get; set; }
        public string? Block { get; set; }
        public int? FlatNumber { get; set; }
        public string? FlatSuffix { get; set; }

        public virtual LocationType LocationType { get; set; }
        public virtual ICollection<Realty> Realties { get; set; }

    }
}
