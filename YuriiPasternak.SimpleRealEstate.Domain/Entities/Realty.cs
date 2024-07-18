using YuriiPasternak.SimpleRealEstate.Domain.Enums;
using YuriiPasternak.SimpleRealEstate.Domain.Identity;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class Realty
    {
        public Realty()
        {
            RealtyPlanningTypes = new HashSet<RealtyPlanningType>();
            RealtyHeatingTypes = new HashSet<RealtyHeatingType>();
            RealtyWallTypes = new HashSet<RealtyWallType>();
        }

        public Guid Id { get; set; }
        public RealtyTypeEnum RealtyTypeId { get; set; }
        public Guid LocationId { get; set; }

        public string Description { get; set; } = string.Empty;
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

        public DateTimeOffset CreatedAt { get; set; }
        public Guid CreatedById { get; set; }

        public virtual AppUser Creator { get; set; } = new();
        public virtual RealtyType RealtyType { get; set; } = new();
        public virtual RealtyStatus RealtyStatus { get; set; } = new();
        public virtual Location Location { get; set; } = new();
        public virtual ICollection<RealtyPlanningType> RealtyPlanningTypes { get; set; }
        public virtual ICollection<RealtyHeatingType> RealtyHeatingTypes { get; set; }
        public virtual ICollection<RealtyWallType> RealtyWallTypes { get; set; }
    }
}
