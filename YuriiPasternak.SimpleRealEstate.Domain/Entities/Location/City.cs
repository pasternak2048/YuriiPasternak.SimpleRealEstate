namespace YuriiPasternak.SimpleRealEstate.Domain.Entities.Location
{
    public class City
    {
        public City() {
            Streets = new HashSet<Street>();
            CityAreas = new HashSet<CityArea>();
        }
        public Guid Id { get; set; }

        public Guid? TerritorialCommunityId { get; set; }
        public string? Name { get; set; }
        public string? KATOTTG { get; set; }
        public bool? HasSpecialStatus { get; set; }

        public TerritorialCommunity TerritorialCommunity { get; set; }
        public ICollection<Street> Streets { get; set; }
        public ICollection<CityArea> CityAreas { get; set; }
    }
}
