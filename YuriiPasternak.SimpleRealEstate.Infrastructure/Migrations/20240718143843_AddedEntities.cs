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
                name: "HeatingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanningType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealtyStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealtyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WallType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WallType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
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
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_LocationType_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Realty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealtyTypeId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Realty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Realty_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Realty_RealtyStatus_RealtyStatusId",
                        column: x => x.RealtyStatusId,
                        principalTable: "RealtyStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Realty_RealtyType_RealtyTypeId",
                        column: x => x.RealtyTypeId,
                        principalTable: "RealtyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealtyHeatingType",
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
                    table.PrimaryKey("PK_RealtyHeatingType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealtyHeatingType_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealtyHeatingType_HeatingType_HeatingTypeId",
                        column: x => x.HeatingTypeId,
                        principalTable: "HeatingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyHeatingType_Realty_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealtyPlanningType",
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
                    table.PrimaryKey("PK_RealtyPlanningType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealtyPlanningType_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealtyPlanningType_PlanningType_PlanningTypeId",
                        column: x => x.PlanningTypeId,
                        principalTable: "PlanningType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyPlanningType_Realty_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealtyWallType",
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
                    table.PrimaryKey("PK_RealtyWallType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealtyWallType_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealtyWallType_Realty_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyWallType_WallType_WallTypeId",
                        column: x => x.WallTypeId,
                        principalTable: "WallType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HeatingType",
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
                table: "PlanningType",
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
                table: "RealtyStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Unknown" },
                    { 1, "Draft" },
                    { 2, "NonVerified" },
                    { 3, "Verified" }
                });

            migrationBuilder.InsertData(
                table: "RealtyType",
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
                table: "WallType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Brick" },
                    { 2, "Concrete" },
                    { 3, "Wood" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_LocationTypeId",
                table: "Location",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Realty_CreatedById",
                table: "Realty",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Realty_RealtyStatusId",
                table: "Realty",
                column: "RealtyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Realty_RealtyTypeId",
                table: "Realty",
                column: "RealtyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingType_CreatedById",
                table: "RealtyHeatingType",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingType_HeatingTypeId",
                table: "RealtyHeatingType",
                column: "HeatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingType_RealtyId",
                table: "RealtyHeatingType",
                column: "RealtyId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningType_CreatedById",
                table: "RealtyPlanningType",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningType_PlanningTypeId",
                table: "RealtyPlanningType",
                column: "PlanningTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningType_RealtyId",
                table: "RealtyPlanningType",
                column: "RealtyId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyWallType_CreatedById",
                table: "RealtyWallType",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyWallType_RealtyId",
                table: "RealtyWallType",
                column: "RealtyId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyWallType_WallTypeId",
                table: "RealtyWallType",
                column: "WallTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "RealtyHeatingType");

            migrationBuilder.DropTable(
                name: "RealtyPlanningType");

            migrationBuilder.DropTable(
                name: "RealtyWallType");

            migrationBuilder.DropTable(
                name: "LocationType");

            migrationBuilder.DropTable(
                name: "HeatingType");

            migrationBuilder.DropTable(
                name: "PlanningType");

            migrationBuilder.DropTable(
                name: "Realty");

            migrationBuilder.DropTable(
                name: "WallType");

            migrationBuilder.DropTable(
                name: "RealtyStatus");

            migrationBuilder.DropTable(
                name: "RealtyType");
        }
    }
}
