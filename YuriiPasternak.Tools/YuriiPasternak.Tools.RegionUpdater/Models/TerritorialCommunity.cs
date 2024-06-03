using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.RegionUpdater.Models;

public partial class TerritorialCommunity
{
    public Guid Id { get; set; }

    public Guid? DistrictId { get; set; }

    public string? Name { get; set; }

    public string? Katottg { get; set; }

    public bool? HasSpecialStatus { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual District? District { get; set; }
}
