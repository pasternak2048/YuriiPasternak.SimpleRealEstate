using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.Shared.Models;

public partial class Realty
{
    public Guid Id { get; set; }

    public string Description { get; set; } = null!;

    public int RealtyTypeId { get; set; }

    public Guid TerritorialObjectId { get; set; }

    public int? Floor { get; set; }

    public bool? IsFirstFloor { get; set; }

    public bool? IsLastFloor { get; set; }

    public int? FloorCount { get; set; }

    public double? Area { get; set; }

    public int? RoomCount { get; set; }

    public int? BathCount { get; set; }

    public DateTimeOffset? BuildDate { get; set; }

    public int RealtyStatusId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public Guid CreatedById { get; set; }

    public DateTimeOffset? ModifiedAt { get; set; }

    public Guid? ModifiedById { get; set; }

    public virtual AspNetUser CreatedBy { get; set; } = null!;

    public virtual AspNetUser? ModifiedBy { get; set; }

    public virtual ICollection<RealtyHeatingType> RealtyHeatingTypes { get; set; } = new List<RealtyHeatingType>();

    public virtual ICollection<RealtyPlanningType> RealtyPlanningTypes { get; set; } = new List<RealtyPlanningType>();

    public virtual RealtyStatus RealtyStatus { get; set; } = null!;

    public virtual RealtyType RealtyType { get; set; } = null!;

    public virtual ICollection<RealtyWallType> RealtyWallTypes { get; set; } = new List<RealtyWallType>();

    public virtual TerritorialObject TerritorialObject { get; set; } = null!;
}
