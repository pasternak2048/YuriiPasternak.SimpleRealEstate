using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class WallType
    {
        public WallType()
        {
            RealtyWallTypes = new HashSet<RealtyWallType>();
        }
        public WallTypeEnum Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<RealtyWallType> RealtyWallTypes { get; set; }
    }
}
