namespace YuriiPasternak.SimpleRealEstate.Domain.Entities.Location
{
    public class Address
    {
        public Address() {
            Realties = new HashSet<Realty>();
        }

        public Guid Id { get; set; }
        public Guid? StreetId { get; set; }
        public int? BuildingNumber { get; set; }
        public string? Block {  get; set; }
        public int? ApartmentNumber { get; set; }

        public Street Street { get; set; }
        public ICollection<Realty> Realties { get; set; }
    }
}
