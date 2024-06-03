using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.RegionUpdater.Models;

public partial class RealtyPlanningType
{
    public Guid Id { get; set; }

    public Guid RealtyId { get; set; }

    public int PlanningTypeId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public Guid CreatedById { get; set; }

    public DateTimeOffset? ModifiedAt { get; set; }

    public Guid? ModifiedById { get; set; }

    public virtual AspNetUser CreatedBy { get; set; } = null!;

    public virtual AspNetUser? ModifiedBy { get; set; }

    public virtual PlanningType PlanningType { get; set; } = null!;

    public virtual Realty Realty { get; set; } = null!;
}
