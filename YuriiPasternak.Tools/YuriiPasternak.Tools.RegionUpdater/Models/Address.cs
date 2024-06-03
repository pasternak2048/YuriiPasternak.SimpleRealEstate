using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.RegionUpdater.Models;

public partial class Address
{
    public Guid Id { get; set; }

    public Guid? StreetId { get; set; }

    public int? BuildingNumber { get; set; }

    public string? Block { get; set; }

    public int? ApartmentNumber { get; set; }

    public virtual ICollection<Realty> Realties { get; set; } = new List<Realty>();

    public virtual Street? Street { get; set; }
}
