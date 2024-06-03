using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.RegionUpdater.Models;

public partial class HeatingType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<RealtyHeatingType> RealtyHeatingTypes { get; set; } = new List<RealtyHeatingType>();
}
