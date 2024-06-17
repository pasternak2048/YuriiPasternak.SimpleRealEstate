using System;
using System.Collections.Generic;
using YuriiPasternak.Tools.Shared.Enums;

namespace YuriiPasternak.Tools.Shared.Models;

public partial class TerritorialObjectType
{
    public TerritorialObjectTypeEnum Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TerritorialObject> TerritorialObjects { get; set; } = new List<TerritorialObject>();
}
