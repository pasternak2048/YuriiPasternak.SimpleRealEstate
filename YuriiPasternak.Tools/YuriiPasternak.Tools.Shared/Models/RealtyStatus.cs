using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.Shared.Models;

public partial class RealtyStatus
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Realty> Realties { get; set; } = new List<Realty>();
}
