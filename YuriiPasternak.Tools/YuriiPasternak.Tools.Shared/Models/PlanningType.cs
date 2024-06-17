using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.Shared.Models;

public partial class PlanningType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<RealtyPlanningType> RealtyPlanningTypes { get; set; } = new List<RealtyPlanningType>();
}
