namespace YuriiPasternak.SimpleRealEstate.Domain.Entities.Location
{
    public class Street
    {
        public Street() {
            Addresses = new HashSet<Address>();
        }

        public Guid Id { get; set; }
        public Guid? CityId { get; set; }
        public Guid? CityAreaId { get; set; }
        public string? Name { get; set; }

        public City City { get; set; }
        public CityArea CityArea { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
