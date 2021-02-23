using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalInformationService.DataAccess.Migrations
{
    public partial class FixManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineActiveSubstances_ActiveSubstances_MedicineId",
                table: "MedicineActiveSubstances");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineActiveSubstances_Medicines_ActiveSubstanceId",
                table: "MedicineActiveSubstances");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineActiveSubstances_ActiveSubstances_ActiveSubstanceId",
                table: "MedicineActiveSubstances",
                column: "ActiveSubstanceId",
                principalTable: "ActiveSubstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineActiveSubstances_Medicines_MedicineId",
                table: "MedicineActiveSubstances",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineActiveSubstances_ActiveSubstances_ActiveSubstanceId",
                table: "MedicineActiveSubstances");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineActiveSubstances_Medicines_MedicineId",
                table: "MedicineActiveSubstances");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineActiveSubstances_ActiveSubstances_MedicineId",
                table: "MedicineActiveSubstances",
                column: "MedicineId",
                principalTable: "ActiveSubstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineActiveSubstances_Medicines_ActiveSubstanceId",
                table: "MedicineActiveSubstances",
                column: "ActiveSubstanceId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
