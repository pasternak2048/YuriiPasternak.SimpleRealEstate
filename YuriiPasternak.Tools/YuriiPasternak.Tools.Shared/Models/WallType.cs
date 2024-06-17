using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.Shared.Models;

public partial class WallType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<RealtyWallType> RealtyWallTypes { get; set; } = new List<RealtyWallType>();
}
