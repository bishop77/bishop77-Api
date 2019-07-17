using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiWeb.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_color_leather",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "RegionId_region",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeatherId_leather",
                table: "Animals",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId_location",
                table: "Animals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RegionId_region",
                table: "Locations",
                column: "RegionId_region");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_LeatherId_leather",
                table: "Animals",
                column: "LeatherId_leather");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_LocationId_location",
                table: "Animals",
                column: "LocationId_location");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Leathers_LeatherId_leather",
                table: "Animals",
                column: "LeatherId_leather",
                principalTable: "Leathers",
                principalColumn: "Id_leather",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Locations_LocationId_location",
                table: "Animals",
                column: "LocationId_location",
                principalTable: "Locations",
                principalColumn: "Id_location",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Regions_RegionId_region",
                table: "Locations",
                column: "RegionId_region",
                principalTable: "Regions",
                principalColumn: "Id_region",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Leathers_LeatherId_leather",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Locations_LocationId_location",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Regions_RegionId_region",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_RegionId_region",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Animals_LeatherId_leather",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_LocationId_location",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "RegionId_region",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LeatherId_leather",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "LocationId_location",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "id_color_leather",
                table: "Animals",
                nullable: false,
                defaultValue: 0);
        }
    }
}
