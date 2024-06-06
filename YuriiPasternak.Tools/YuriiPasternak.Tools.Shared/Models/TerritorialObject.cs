using System;
using System.Collections.Generic;
using YuriiPasternak.Tools.Shared.Enums;

namespace YuriiPasternak.Tools.Shared.Models;

public partial class TerritorialObject
{
    public Guid Id { get; set; }

    public Guid? RegionId { get; set; }

    public Guid? DistrictId { get; set; }

    public Guid? CommunityId { get; set; }

    public Guid? LocalityId { get; set; }

    public string? Name { get; set; }

    public string? Katottg { get; set; }

    public string? RegionKatottg { get; set; }

    public string? DistrictKatottg { get; set; }

    public string? CommunityKatottg { get; set; }

    public string? LocalityKatottg { get; set; }

    public TerritorialObjectTypeEnum TypeId { get; set; }

    public virtual ICollection<Realty> Realties { get; set; } = new List<Realty>();

    public virtual TerritorialObjectType Type { get; set; } = null!;
}
