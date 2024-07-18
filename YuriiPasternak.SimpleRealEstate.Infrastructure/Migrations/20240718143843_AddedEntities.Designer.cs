﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YuriiPasternak.SimpleRealEstate.Infrastructure.Context;

#nullable disable

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Migrations
{
    [DbContext(typeof(SimpleRealEstateDbContext))]
    [Migration("20240718143843_AddedEntities")]
    partial class AddedEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.HeatingType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HeatingType");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "None"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Electric"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Gas"
                        },
                        new
                        {
                            Id = 3,
                            Name = "SolidFuel"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Solar"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Geothermal"
                        });
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BuildingNumber")
                        .HasColumnType("int");

                    b.Property<string>("Community")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FlatNumber")
                        .HasColumnType("int");

                    b.Property<string>("FlatSuffix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Locality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalityDistrict")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationTypeId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.LocationType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LocationType");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.PlanningType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlanningType");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "None"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Jacuzzi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "MultiLevel"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Terrace"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Penthouse"
                        },
                        new
                        {
                            Id = 5,
                            Name = "WithoutFurniture"
                        });
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.Realty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Area")
                        .HasColumnType("float");

                    b.Property<int?>("BathCount")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("BuildDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Floor")
                        .HasColumnType("int");

                    b.Property<int?>("FloorCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool?>("IsFirstFloor")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsLastFloor")
                        .HasColumnType("bit");

                    b.Property<int>("RealtyStatusId")
                        .HasColumnType("int");

                    b.Property<int>("RealtyTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("RoomCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("RealtyStatusId");

                    b.HasIndex("RealtyTypeId");

                    b.ToTable("Realty");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.RealtyHeatingType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("HeatingTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("RealtyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("HeatingTypeId");

                    b.HasIndex("RealtyId");

                    b.ToTable("RealtyHeatingType");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.RealtyPlanningType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("PlanningTypeId")
                        .HasColumnType("int");

                    b.Property<Guid>("RealtyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PlanningTypeId");

                    b.HasIndex("RealtyId");

                    b.ToTable("RealtyPlanningType");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.RealtyStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RealtyStatus");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "Unknown"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Draft"
                        },
                        new
                        {
                            Id = 2,
                            Name = "NonVerified"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Verified"
                        });
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.RealtyType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RealtyType");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "None"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Flat"
                        },
                        new
                        {
                            Id = 2,
                            Name = "House"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Commercial"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Planning"
                        },
                        new
                        {
                            Id = 5,
                            Name = "PlaceOnly"
                        });
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.RealtyWallType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("RealtyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("WallTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("RealtyId");

                    b.HasIndex("WallTypeId");

                    b.ToTable("RealtyWallType");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.WallType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WallType");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "None"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Brick"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Concrete"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Wood"
                        });
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Identity.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Identity.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.Location", b =>
                {
                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Entities.LocationType", "LocationType")
                        .WithMany("Locations")
                        .HasForeignKey("LocationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocationType");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.Realty", b =>
                {
                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Identity.AppUser", "Creator")
                        .WithMany("Realties")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Entities.RealtyStatus", "RealtyStatus")
                        .WithMany("Realties")
                        .HasForeignKey("RealtyStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Entities.RealtyType", "RealtyType")
                        .WithMany("Realties")
                        .HasForeignKey("RealtyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("RealtyStatus");

                    b.Navigation("RealtyType");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.RealtyHeatingType", b =>
                {
                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Identity.AppUser", "Creator")
                        .WithMany("RealtyHeatingTypes")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Entities.HeatingType", "HeatingType")
                        .WithMany("RealtyHeatingTypes")
                        .HasForeignKey("HeatingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Entities.Realty", "Realty")
                        .WithMany("RealtyHeatingTypes")
                        .HasForeignKey("RealtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("HeatingType");

                    b.Navigation("Realty");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.RealtyPlanningType", b =>
                {
                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Identity.AppUser", "Creator")
                        .WithMany("RealtyPlanningTypes")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Entities.PlanningType", "PlanningType")
                        .WithMany("RealtyPlanningTypes")
                        .HasForeignKey("PlanningTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Entities.Realty", "Realty")
                        .WithMany("RealtyPlanningTypes")
                        .HasForeignKey("RealtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("PlanningType");

                    b.Navigation("Realty");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.RealtyWallType", b =>
                {
                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Identity.AppUser", "Creator")
                        .WithMany("RealtyWallTypes")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Entities.Realty", "Realty")
                        .WithMany("RealtyWallTypes")
                        .HasForeignKey("RealtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YuriiPasternak.SimpleRealEstate.Domain.Entities.WallType", "WallType")
                        .WithMany("RealtyWallTypes")
                        .HasForeignKey("WallTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Realty");

                    b.Navigation("WallType");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.HeatingType", b =>
                {
                    b.Navigation("RealtyHeatingTypes");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.LocationType", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.PlanningType", b =>
                {
                    b.Navigation("RealtyPlanningTypes");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.Realty", b =>
                {
                    b.Navigation("RealtyHeatingTypes");

                    b.Navigation("RealtyPlanningTypes");

                    b.Navigation("RealtyWallTypes");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.RealtyStatus", b =>
                {
                    b.Navigation("Realties");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.RealtyType", b =>
                {
                    b.Navigation("Realties");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Entities.WallType", b =>
                {
                    b.Navigation("RealtyWallTypes");
                });

            modelBuilder.Entity("YuriiPasternak.SimpleRealEstate.Domain.Identity.AppUser", b =>
                {
                    b.Navigation("Realties");

                    b.Navigation("RealtyHeatingTypes");

                    b.Navigation("RealtyPlanningTypes");

                    b.Navigation("RealtyWallTypes");
                });
#pragma warning restore 612, 618
        }
    }
}