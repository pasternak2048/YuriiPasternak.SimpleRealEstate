using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.RegionUpdater.Models;

public partial class CityArea
{
    public Guid Id { get; set; }

    public Guid? CityId { get; set; }

    public string? Name { get; set; }

    public string? Katottg { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Street> Streets { get; set; } = new List<Street>();
}
