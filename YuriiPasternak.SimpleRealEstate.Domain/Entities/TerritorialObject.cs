using System.Collections;
using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class TerritorialObject
    {
        public TerritorialObject() {
            Realties = new HashSet<Realty>();
        }

        public Guid Id { get; set; }
        public Guid? RegionId { get; set; }
        public Guid? DistrictId { get; set; }
        public Guid? CommunityId { get; set; }
        public Guid? LocalityId { get; set; }
        public string? Name { get; set; }
        public string? KATOTTG { get; set; }
        public string? RegionKATOTTG { get; set; }
        public string? DistrictKATOTTG { get; set; }
        public string? CommunityKATOTTG { get; set; }
        public string? LocalityKATOTTG { get; set; }
        public TerritorialObjectTypeEnum TypeId { get; set; } = TerritorialObjectTypeEnum.None;

        public virtual TerritorialObjectType TerritorialObjectType { get; set; }
        public virtual ICollection<Realty> Realties { get; set; }
    }
}
