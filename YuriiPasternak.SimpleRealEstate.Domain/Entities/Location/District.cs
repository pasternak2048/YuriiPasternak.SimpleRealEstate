namespace YuriiPasternak.SimpleRealEstate.Domain.Entities.Location
{
    public class District
    {
        public District() {
            TerritorialCommunities = new HashSet<TerritorialCommunity>();
        }

        public Guid Id { get; set; }
        public Guid? RegionId { get; set; }
        public string? Name { get; set; }
        public string? KATOTTG { get; set; }

        public Region Region { get; set; }
        public ICollection<TerritorialCommunity> TerritorialCommunities { get; set; }
    }
}
