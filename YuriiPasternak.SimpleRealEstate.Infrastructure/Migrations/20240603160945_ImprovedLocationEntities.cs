using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImprovedLocationEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Realties_Locations_LocationId",
                table: "Realties");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "LocationTypes");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Realties",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Realties_LocationId",
                table: "Realties",
                newName: "IX_Realties_AddressId");

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KATOTTG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasSpecialStatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KATOTTG = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Districts_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TerritorialCommunities",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KATOTTG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasSpecialStatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritorialCommunities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TerritorialCommunities_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerritorialCommunityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KATOTTG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasSpecialStatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cities_TerritorialCommunities_TerritorialCommunityId",
                        column: x => x.TerritorialCommunityId,
                        principalTable: "TerritorialCommunities",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CityAreas",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KATOTTG = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityAreas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CityAreas_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Streets_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Streets_CityAreas_CityAreaId",
                        column: x => x.CityAreaId,
                        principalTable: "CityAreas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StreetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BuildingNumber = table.Column<int>(type: "int", nullable: true),
                    Block = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApartmentNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresses_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StreetId",
                table: "Addresses",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_TerritorialCommunityId",
                table: "Cities",
                column: "TerritorialCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityAreas_CityId",
                table: "CityAreas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_RegionId",
                table: "Districts",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_CityAreaId",
                table: "Streets",
                column: "CityAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_CityId",
                table: "Streets",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TerritorialCommunities_DistrictId",
                table: "TerritorialCommunities",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Realties_Addresses_AddressId",
                table: "Realties",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Realties_Addresses_AddressId",
                table: "Realties");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "CityAreas");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "TerritorialCommunities");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Realties",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Realties_AddressId",
                table: "Realties",
                newName: "IX_Realties_LocationId");

            migrationBuilder.CreateTable(
                name: "LocationTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LocationTypeId = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Locations_LocationTypes_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Locations_Locations_CityAreaId",
                        column: x => x.CityAreaId,
                        principalTable: "Locations",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Locations_Locations_CityId",
                        column: x => x.CityId,
                        principalTable: "Locations",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Locations_Locations_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Locations",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Locations_Locations_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Locations",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "LocationTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Street" },
                    { 2, "CityArea" },
                    { 3, "City" },
                    { 4, "District" },
                    { 5, "Region" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CityAreaId",
                table: "Locations",
                column: "CityAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CityId",
                table: "Locations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_DistrictId",
                table: "Locations",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationTypeId",
                table: "Locations",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RegionId",
                table: "Locations",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Realties_Locations_LocationId",
                table: "Realties",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
