using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.Shared.Models;

public partial class RealtyHeatingType
{
    public Guid Id { get; set; }

    public Guid RealtyId { get; set; }

    public int HeatingTypeId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public Guid CreatedById { get; set; }

    public DateTimeOffset? ModifiedAt { get; set; }

    public Guid? ModifiedById { get; set; }

    public virtual AspNetUser CreatedBy { get; set; } = null!;

    public virtual HeatingType HeatingType { get; set; } = null!;

    public virtual AspNetUser? ModifiedBy { get; set; }

    public virtual Realty Realty { get; set; } = null!;
}
