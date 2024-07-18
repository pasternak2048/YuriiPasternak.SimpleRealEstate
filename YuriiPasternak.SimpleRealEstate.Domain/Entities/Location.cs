using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class Location
    {
        public Location() { }
        public Guid Id { get; set; }
        public LocationTypeEnum LocationTypeId { get; set; }
        public string Region { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Community { get; set; } = string.Empty;
        public string Locality { get; set; } = string.Empty;
        public string LocalityDistrict { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int? BuildingNumber { get; set; }
        public string Block { get; set; } = string.Empty;
        public int? FlatNumber { get; set; }
        public string FlatSuffix { get; set; } = string.Empty;

        public virtual LocationType LocationType { get; set; } = new();

    }
}
