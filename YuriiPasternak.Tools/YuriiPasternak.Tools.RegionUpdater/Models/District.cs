using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.RegionUpdater.Models;

public partial class District
{
    public Guid Id { get; set; }

    public Guid? RegionId { get; set; }

    public string? Name { get; set; }

    public string? Katottg { get; set; }

    public virtual Region? Region { get; set; }

    public virtual ICollection<TerritorialCommunity> TerritorialCommunities { get; set; } = new List<TerritorialCommunity>();
}
