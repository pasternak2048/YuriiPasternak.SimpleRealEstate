using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.RegionUpdater.Models;

public partial class City
{
    public Guid Id { get; set; }

    public Guid? TerritorialCommunityId { get; set; }

    public string? Name { get; set; }

    public string? Katottg { get; set; }

    public bool? HasSpecialStatus { get; set; }

    public virtual ICollection<CityArea> CityAreas { get; set; } = new List<CityArea>();

    public virtual ICollection<Street> Streets { get; set; } = new List<Street>();

    public virtual TerritorialCommunity? TerritorialCommunity { get; set; }
}
