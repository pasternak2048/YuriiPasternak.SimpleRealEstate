using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.RegionUpdater.Models;

public partial class Street
{
    public Guid Id { get; set; }

    public Guid? CityId { get; set; }

    public Guid? CityAreaId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual City? City { get; set; }

    public virtual CityArea? CityArea { get; set; }
}
