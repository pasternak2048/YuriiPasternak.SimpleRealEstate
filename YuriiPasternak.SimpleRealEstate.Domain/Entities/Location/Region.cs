namespace YuriiPasternak.SimpleRealEstate.Domain.Entities.Location
{
    public class Region
    {
        public Region() {
            Districts = new HashSet<District>();    
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? KATOTTG { get; set; }
        public bool? HasSpecialStatus { get; set; }

        public ICollection<District> Districts { get; set; }
    }
}
