using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeatingTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatingTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlanningTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RealtyStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RealtyTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TerritorialObjectTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritorialObjectTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WallTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WallTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TerritorialObjects",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommunityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LocalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KATOTTG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionKATOTTG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictKATOTTG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommunityKATOTTG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalityKATOTTG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritorialObjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TerritorialObjects_TerritorialObjectTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TerritorialObjectTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Realties",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealtyTypeId = table.Column<int>(type: "int", nullable: false),
                    TerritorialObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: true),
                    IsFirstFloor = table.Column<bool>(type: "bit", nullable: true),
                    IsLastFloor = table.Column<bool>(type: "bit", nullable: true),
                    FloorCount = table.Column<int>(type: "int", nullable: true),
                    Area = table.Column<double>(type: "float", nullable: true),
                    RoomCount = table.Column<int>(type: "int", nullable: true),
                    BathCount = table.Column<int>(type: "int", nullable: true),
                    BuildDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    RealtyStatusId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Realties_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Realties_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Realties_RealtyStatuses_RealtyStatusId",
                        column: x => x.RealtyStatusId,
                        principalTable: "RealtyStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Realties_RealtyTypes_RealtyTypeId",
                        column: x => x.RealtyTypeId,
                        principalTable: "RealtyTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Realties_TerritorialObjects_TerritorialObjectId",
                        column: x => x.TerritorialObjectId,
                        principalTable: "TerritorialObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealtyHeatingTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeatingTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyHeatingTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RealtyHeatingTypes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealtyHeatingTypes_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealtyHeatingTypes_HeatingTypes_HeatingTypeId",
                        column: x => x.HeatingTypeId,
                        principalTable: "HeatingTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyHeatingTypes_Realties_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealtyPlanningTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanningTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyPlanningTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RealtyPlanningTypes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealtyPlanningTypes_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealtyPlanningTypes_PlanningTypes_PlanningTypeId",
                        column: x => x.PlanningTypeId,
                        principalTable: "PlanningTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyPlanningTypes_Realties_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealtyWallTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WallTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyWallTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RealtyWallTypes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealtyWallTypes_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealtyWallTypes_Realties_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyWallTypes_WallTypes_WallTypeId",
                        column: x => x.WallTypeId,
                        principalTable: "WallTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HeatingTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Electric" },
                    { 2, "Gas" },
                    { 3, "SolidFuel" },
                    { 4, "Solar" },
                    { 5, "Geothermal" }
                });

            migrationBuilder.InsertData(
                table: "PlanningTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Jacuzzi" },
                    { 2, "MultiLevel" },
                    { 3, "Terrace" },
                    { 4, "Penthouse" },
                    { 5, "WithoutFurniture" }
                });

            migrationBuilder.InsertData(
                table: "RealtyStatuses",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 0, "Unknown" },
                    { 1, "Draft" },
                    { 2, "NonVerified" },
                    { 3, "Verified" }
                });

            migrationBuilder.InsertData(
                table: "RealtyTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Flat" },
                    { 2, "House" },
                    { 3, "Commercial" },
                    { 4, "Planning" },
                    { 5, "PlaceOnly" }
                });

            migrationBuilder.InsertData(
                table: "TerritorialObjectTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Region" },
                    { 2, "District" },
                    { 3, "Community" },
                    { 4, "City" },
                    { 5, "CityDistrict" },
                    { 6, "Village" },
                    { 7, "SmallTown" }
                });

            migrationBuilder.InsertData(
                table: "WallTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Brick" },
                    { 2, "Concrete" },
                    { 3, "Wood" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_CreatedById",
                table: "Realties",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_ModifiedById",
                table: "Realties",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_RealtyStatusId",
                table: "Realties",
                column: "RealtyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_RealtyTypeId",
                table: "Realties",
                column: "RealtyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_TerritorialObjectId",
                table: "Realties",
                column: "TerritorialObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingTypes_CreatedById",
                table: "RealtyHeatingTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingTypes_HeatingTypeId",
                table: "RealtyHeatingTypes",
                column: "HeatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingTypes_ModifiedById",
                table: "RealtyHeatingTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingTypes_RealtyId",
                table: "RealtyHeatingTypes",
                column: "RealtyId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningTypes_CreatedById",
                table: "RealtyPlanningTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningTypes_ModifiedById",
                table: "RealtyPlanningTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningTypes_PlanningTypeId",
                table: "RealtyPlanningTypes",
                column: "PlanningTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningTypes_RealtyId",
                table: "RealtyPlanningTypes",
                column: "RealtyId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyWallTypes_CreatedById",
                table: "RealtyWallTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyWallTypes_ModifiedById",
                table: "RealtyWallTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyWallTypes_RealtyId",
                table: "RealtyWallTypes",
                column: "RealtyId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyWallTypes_WallTypeId",
                table: "RealtyWallTypes",
                column: "WallTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TerritorialObjects_TypeId",
                table: "TerritorialObjects",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RealtyHeatingTypes");

            migrationBuilder.DropTable(
                name: "RealtyPlanningTypes");

            migrationBuilder.DropTable(
                name: "RealtyWallTypes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "HeatingTypes");

            migrationBuilder.DropTable(
                name: "PlanningTypes");

            migrationBuilder.DropTable(
                name: "Realties");

            migrationBuilder.DropTable(
                name: "WallTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "RealtyStatuses");

            migrationBuilder.DropTable(
                name: "RealtyTypes");

            migrationBuilder.DropTable(
                name: "TerritorialObjects");

            migrationBuilder.DropTable(
                name: "TerritorialObjectTypes");
        }
    }
}
