using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoCare.Migrations
{
    /// <inheritdoc />
    public partial class AddCarCollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VignetteRecords_CarId",
                table: "VignetteRecords");

            migrationBuilder.DropIndex(
                name: "IX_TechnicalInspectionRecords_CarId",
                table: "TechnicalInspectionRecords");

            migrationBuilder.DropIndex(
                name: "IX_OilServiceRecords_CarId",
                table: "OilServiceRecords");

            migrationBuilder.DropIndex(
                name: "IX_CivilLiabilityInsurances_CarId",
                table: "CivilLiabilityInsurances");

            migrationBuilder.DropIndex(
                name: "IX_BeltServiceRecords_CarId",
                table: "BeltServiceRecords");

            migrationBuilder.CreateIndex(
                name: "IX_VignetteRecords_CarId",
                table: "VignetteRecords",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalInspectionRecords_CarId",
                table: "TechnicalInspectionRecords",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_OilServiceRecords_CarId",
                table: "OilServiceRecords",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CivilLiabilityInsurances_CarId",
                table: "CivilLiabilityInsurances",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_BeltServiceRecords_CarId",
                table: "BeltServiceRecords",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VignetteRecords_CarId",
                table: "VignetteRecords");

            migrationBuilder.DropIndex(
                name: "IX_TechnicalInspectionRecords_CarId",
                table: "TechnicalInspectionRecords");

            migrationBuilder.DropIndex(
                name: "IX_OilServiceRecords_CarId",
                table: "OilServiceRecords");

            migrationBuilder.DropIndex(
                name: "IX_CivilLiabilityInsurances_CarId",
                table: "CivilLiabilityInsurances");

            migrationBuilder.DropIndex(
                name: "IX_BeltServiceRecords_CarId",
                table: "BeltServiceRecords");

            migrationBuilder.CreateIndex(
                name: "IX_VignetteRecords_CarId",
                table: "VignetteRecords",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalInspectionRecords_CarId",
                table: "TechnicalInspectionRecords",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OilServiceRecords_CarId",
                table: "OilServiceRecords",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CivilLiabilityInsurances_CarId",
                table: "CivilLiabilityInsurances",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BeltServiceRecords_CarId",
                table: "BeltServiceRecords",
                column: "CarId",
                unique: true);
        }
    }
}
