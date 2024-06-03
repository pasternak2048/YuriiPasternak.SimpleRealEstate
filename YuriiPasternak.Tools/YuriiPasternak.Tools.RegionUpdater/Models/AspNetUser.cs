using System;
using System.Collections.Generic;

namespace YuriiPasternak.Tools.RegionUpdater.Models;

public partial class AspNetUser
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; } = new List<AspNetUserToken>();

    public virtual ICollection<Realty> RealtyCreatedBies { get; set; } = new List<Realty>();

    public virtual ICollection<RealtyHeatingType> RealtyHeatingTypeCreatedBies { get; set; } = new List<RealtyHeatingType>();

    public virtual ICollection<RealtyHeatingType> RealtyHeatingTypeModifiedBies { get; set; } = new List<RealtyHeatingType>();

    public virtual ICollection<Realty> RealtyModifiedBies { get; set; } = new List<Realty>();

    public virtual ICollection<RealtyPlanningType> RealtyPlanningTypeCreatedBies { get; set; } = new List<RealtyPlanningType>();

    public virtual ICollection<RealtyPlanningType> RealtyPlanningTypeModifiedBies { get; set; } = new List<RealtyPlanningType>();

    public virtual ICollection<RealtyWallType> RealtyWallTypeCreatedBies { get; set; } = new List<RealtyWallType>();

    public virtual ICollection<RealtyWallType> RealtyWallTypeModifiedBies { get; set; } = new List<RealtyWallType>();

    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();
}
