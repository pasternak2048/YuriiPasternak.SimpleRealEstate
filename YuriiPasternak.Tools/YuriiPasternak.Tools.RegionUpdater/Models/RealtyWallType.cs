using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.RegionUpdater.Models;

public partial class RealtyWallType
{
    public Guid Id { get; set; }

    public Guid RealtyId { get; set; }

    public int WallTypeId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public Guid CreatedById { get; set; }

    public DateTimeOffset? ModifiedAt { get; set; }

    public Guid? ModifiedById { get; set; }

    public virtual AspNetUser CreatedBy { get; set; } = null!;

    public virtual AspNetUser? ModifiedBy { get; set; }

    public virtual Realty Realty { get; set; } = null!;

    public virtual WallType WallType { get; set; } = null!;
}
