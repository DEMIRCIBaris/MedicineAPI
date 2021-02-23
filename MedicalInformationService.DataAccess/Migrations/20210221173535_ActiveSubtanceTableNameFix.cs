using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalInformationService.DataAccess.Migrations
{
    public partial class ActiveSubtanceTableNameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ActiveSubstances",
                newName: "SubstanceName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubstanceName",
                table: "ActiveSubstances",
                newName: "Name");
        }
    }
}
