using YuriiPasternak.SimpleRealEstate.Domain.Common;
using YuriiPasternak.SimpleRealEstate.Domain.Entities.Location;
using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class Realty : AuditableEntity
    {
        public Realty()
        {
            RealtyPlanningTypes = new HashSet<RealtyPlanningType>();
            RealtyHeatingTypes = new HashSet<RealtyHeatingType>();
            RealtyWallTypes = new HashSet<RealtyWallType>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public RealtyTypeEnum RealtyTypeId { get; set; }
        public Guid AddressId { get; set; }
        public int? Floor { get; set; }
        public bool? IsFirstFloor { get; set; }
        public bool? IsLastFloor { get; set; }
        public int? FloorCount { get; set; }
        public double? Area { get; set; }
        public int? RoomCount { get; set; }
        public int? BathCount { get; set; }
        public DateTimeOffset? BuildDate { get; set; }
        public RealtyStatusEnum RealtyStatusId { get; set; } = RealtyStatusEnum.Draft;
        public bool IsDeleted { get; set; } = false;

        public virtual RealtyType RealtyType { get; set; }
        public virtual Address Address { get; set; }
        public virtual RealtyStatus RealtyStatus { get; set; }
        public virtual ICollection<RealtyPlanningType> RealtyPlanningTypes { get; set; }
        public virtual ICollection<RealtyHeatingType> RealtyHeatingTypes { get; set; }
        public virtual ICollection<RealtyWallType> RealtyWallTypes { get; set; }
    }
}
