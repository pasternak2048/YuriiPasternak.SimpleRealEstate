using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace YuriiPasternak.Tools.Shared.Models;

public partial class YuriiPasternakSimpleRealEstateDbContext : DbContext
{
    public YuriiPasternakSimpleRealEstateDbContext()
    {
    }

    public YuriiPasternakSimpleRealEstateDbContext(DbContextOptions<YuriiPasternakSimpleRealEstateDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<HeatingType> HeatingTypes { get; set; }

    public virtual DbSet<PlanningType> PlanningTypes { get; set; }

    public virtual DbSet<Realty> Realties { get; set; }

    public virtual DbSet<RealtyHeatingType> RealtyHeatingTypes { get; set; }

    public virtual DbSet<RealtyPlanningType> RealtyPlanningTypes { get; set; }

    public virtual DbSet<RealtyStatus> RealtyStatuses { get; set; }

    public virtual DbSet<RealtyType> RealtyTypes { get; set; }

    public virtual DbSet<RealtyWallType> RealtyWallTypes { get; set; }

    public virtual DbSet<TerritorialObject> TerritorialObjects { get; set; }

    public virtual DbSet<TerritorialObjectType> TerritorialObjectTypes { get; set; }

    public virtual DbSet<WallType> WallTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=YuriiPasternak.SimpleRealEstateDb;Persist Security Info=False;User ID=yurii-dev;Password=1111;Connection Timeout=30; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<HeatingType>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<PlanningType>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<Realty>(entity =>
        {
            entity.HasIndex(e => e.CreatedById, "IX_Realties_CreatedById");

            entity.HasIndex(e => e.ModifiedById, "IX_Realties_ModifiedById");

            entity.HasIndex(e => e.RealtyStatusId, "IX_Realties_RealtyStatusId");

            entity.HasIndex(e => e.RealtyTypeId, "IX_Realties_RealtyTypeId");

            entity.HasIndex(e => e.TerritorialObjectId, "IX_Realties_TerritorialObjectId");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.RealtyCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ModifiedBy).WithMany(p => p.RealtyModifiedBies).HasForeignKey(d => d.ModifiedById);

            entity.HasOne(d => d.RealtyStatus).WithMany(p => p.Realties).HasForeignKey(d => d.RealtyStatusId);

            entity.HasOne(d => d.RealtyType).WithMany(p => p.Realties).HasForeignKey(d => d.RealtyTypeId);

            entity.HasOne(d => d.TerritorialObject).WithMany(p => p.Realties).HasForeignKey(d => d.TerritorialObjectId);
        });

        modelBuilder.Entity<RealtyHeatingType>(entity =>
        {
            entity.HasIndex(e => e.CreatedById, "IX_RealtyHeatingTypes_CreatedById");

            entity.HasIndex(e => e.HeatingTypeId, "IX_RealtyHeatingTypes_HeatingTypeId");

            entity.HasIndex(e => e.ModifiedById, "IX_RealtyHeatingTypes_ModifiedById");

            entity.HasIndex(e => e.RealtyId, "IX_RealtyHeatingTypes_RealtyId");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.RealtyHeatingTypeCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.HeatingType).WithMany(p => p.RealtyHeatingTypes).HasForeignKey(d => d.HeatingTypeId);

            entity.HasOne(d => d.ModifiedBy).WithMany(p => p.RealtyHeatingTypeModifiedBies).HasForeignKey(d => d.ModifiedById);

            entity.HasOne(d => d.Realty).WithMany(p => p.RealtyHeatingTypes).HasForeignKey(d => d.RealtyId);
        });

        modelBuilder.Entity<RealtyPlanningType>(entity =>
        {
            entity.HasIndex(e => e.CreatedById, "IX_RealtyPlanningTypes_CreatedById");

            entity.HasIndex(e => e.ModifiedById, "IX_RealtyPlanningTypes_ModifiedById");

            entity.HasIndex(e => e.PlanningTypeId, "IX_RealtyPlanningTypes_PlanningTypeId");

            entity.HasIndex(e => e.RealtyId, "IX_RealtyPlanningTypes_RealtyId");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.RealtyPlanningTypeCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ModifiedBy).WithMany(p => p.RealtyPlanningTypeModifiedBies).HasForeignKey(d => d.ModifiedById);

            entity.HasOne(d => d.PlanningType).WithMany(p => p.RealtyPlanningTypes).HasForeignKey(d => d.PlanningTypeId);

            entity.HasOne(d => d.Realty).WithMany(p => p.RealtyPlanningTypes).HasForeignKey(d => d.RealtyId);
        });

        modelBuilder.Entity<RealtyStatus>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<RealtyType>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<RealtyWallType>(entity =>
        {
            entity.HasIndex(e => e.CreatedById, "IX_RealtyWallTypes_CreatedById");

            entity.HasIndex(e => e.ModifiedById, "IX_RealtyWallTypes_ModifiedById");

            entity.HasIndex(e => e.RealtyId, "IX_RealtyWallTypes_RealtyId");

            entity.HasIndex(e => e.WallTypeId, "IX_RealtyWallTypes_WallTypeId");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.RealtyWallTypeCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ModifiedBy).WithMany(p => p.RealtyWallTypeModifiedBies).HasForeignKey(d => d.ModifiedById);

            entity.HasOne(d => d.Realty).WithMany(p => p.RealtyWallTypes).HasForeignKey(d => d.RealtyId);

            entity.HasOne(d => d.WallType).WithMany(p => p.RealtyWallTypes).HasForeignKey(d => d.WallTypeId);
        });

        modelBuilder.Entity<TerritorialObject>(entity =>
        {
            entity.HasIndex(e => e.TypeId, "IX_TerritorialObjects_TypeId");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CommunityKatottg).HasColumnName("CommunityKATOTTG");
            entity.Property(e => e.DistrictKatottg).HasColumnName("DistrictKATOTTG");
            entity.Property(e => e.Katottg).HasColumnName("KATOTTG");
            entity.Property(e => e.LocalityKatottg).HasColumnName("LocalityKATOTTG");
            entity.Property(e => e.RegionKatottg).HasColumnName("RegionKATOTTG");

            entity.HasOne(d => d.Type).WithMany(p => p.TerritorialObjects).HasForeignKey(d => d.TypeId);
        });

        modelBuilder.Entity<TerritorialObjectType>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<WallType>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
