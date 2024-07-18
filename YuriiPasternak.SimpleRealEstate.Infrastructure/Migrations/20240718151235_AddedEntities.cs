using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeatingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanningTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealtyStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealtyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WallTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WallTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationTypeId = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Community = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalityDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingNumber = table.Column<int>(type: "int", nullable: true),
                    Block = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlatNumber = table.Column<int>(type: "int", nullable: true),
                    FlatSuffix = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_LocationTypes_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Realties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealtyTypeId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Realties_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Realties_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Realties_RealtyStatuses_RealtyStatusId",
                        column: x => x.RealtyStatusId,
                        principalTable: "RealtyStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Realties_RealtyTypes_RealtyTypeId",
                        column: x => x.RealtyTypeId,
                        principalTable: "RealtyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealtyHeatingTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeatingTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyHeatingTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealtyHeatingTypes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealtyHeatingTypes_HeatingTypes_HeatingTypeId",
                        column: x => x.HeatingTypeId,
                        principalTable: "HeatingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyHeatingTypes_Realties_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealtyPlanningTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanningTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyPlanningTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealtyPlanningTypes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealtyPlanningTypes_PlanningTypes_PlanningTypeId",
                        column: x => x.PlanningTypeId,
                        principalTable: "PlanningTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyPlanningTypes_Realties_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealtyWallTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WallTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyWallTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealtyWallTypes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealtyWallTypes_Realties_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyWallTypes_WallTypes_WallTypeId",
                        column: x => x.WallTypeId,
                        principalTable: "WallTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HeatingTypes",
                columns: new[] { "Id", "Name" },
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
                columns: new[] { "Id", "Name" },
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
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Unknown" },
                    { 1, "Draft" },
                    { 2, "NonVerified" },
                    { 3, "Verified" }
                });

            migrationBuilder.InsertData(
                table: "RealtyTypes",
                columns: new[] { "Id", "Name" },
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
                table: "WallTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Brick" },
                    { 2, "Concrete" },
                    { 3, "Wood" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationTypeId",
                table: "Locations",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_CreatedById",
                table: "Realties",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_LocationId",
                table: "Realties",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_RealtyStatusId",
                table: "Realties",
                column: "RealtyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_RealtyTypeId",
                table: "Realties",
                column: "RealtyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingTypes_CreatedById",
                table: "RealtyHeatingTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingTypes_HeatingTypeId",
                table: "RealtyHeatingTypes",
                column: "HeatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingTypes_RealtyId",
                table: "RealtyHeatingTypes",
                column: "RealtyId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningTypes_CreatedById",
                table: "RealtyPlanningTypes",
                column: "CreatedById");

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
                name: "IX_RealtyWallTypes_RealtyId",
                table: "RealtyWallTypes",
                column: "RealtyId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyWallTypes_WallTypeId",
                table: "RealtyWallTypes",
                column: "WallTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealtyHeatingTypes");

            migrationBuilder.DropTable(
                name: "RealtyPlanningTypes");

            migrationBuilder.DropTable(
                name: "RealtyWallTypes");

            migrationBuilder.DropTable(
                name: "HeatingTypes");

            migrationBuilder.DropTable(
                name: "PlanningTypes");

            migrationBuilder.DropTable(
                name: "Realties");

            migrationBuilder.DropTable(
                name: "WallTypes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "RealtyStatuses");

            migrationBuilder.DropTable(
                name: "RealtyTypes");

            migrationBuilder.DropTable(
                name: "LocationTypes");
        }
    }
}
