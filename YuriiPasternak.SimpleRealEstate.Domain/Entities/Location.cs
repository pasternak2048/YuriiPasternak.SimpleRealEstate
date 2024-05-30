using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class Location
    {
        public Location()
        {
            Realties = new HashSet<Realty>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public LocationTypeEnum? LocationTypeId { get; set; }
        public Guid? RegionId { get; set; }
        public Guid? DistrictId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? CityAreaId { get; set; }

        public virtual LocationType LocationType { get; set; }
        public virtual Location Region { get; set; }
        public virtual Location District { get; set; }
        public virtual Location City { get; set; }
        public virtual Location CityArea { get; set; }
        public ICollection<Realty> Realties { get; set; }
    }
}
