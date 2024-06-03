namespace YuriiPasternak.SimpleRealEstate.Domain.Entities.Location
{
    public class CityArea
    {
        public Guid Id { get; set; }
        public Guid? CityId { get; set; }
        public string? Name { get; set; }
        public string? KATOTTG { get; set; }

        public City City { get; set; }
        public ICollection<Street> Streets { get; set; }
    }
}
