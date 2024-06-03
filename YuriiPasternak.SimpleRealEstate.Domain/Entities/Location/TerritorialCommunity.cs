namespace YuriiPasternak.SimpleRealEstate.Domain.Entities.Location
{
    public class TerritorialCommunity
    {
        public TerritorialCommunity() {
            Cities = new HashSet<City>();
        }

        public Guid Id { get; set; }
        public Guid? DistrictId { get; set; }
        public string? Name { get; set; }
        public string? KATOTTG { get; set; }
        public bool? HasSpecialStatus { get; set; }

        public District District { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
