using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.RegionUpdater.Models;

public partial class Region
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Katottg { get; set; }

    public bool? HasSpecialStatus { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();
}
