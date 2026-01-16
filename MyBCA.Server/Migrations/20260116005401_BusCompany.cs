using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBCA.Server.Migrations
{
    /// <inheritdoc />
    public partial class BusCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusInfos_BusCompany_CompanyId",
                table: "BusInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusCompany",
                table: "BusCompany");

            migrationBuilder.RenameTable(
                name: "BusCompany",
                newName: "BusCompanies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusCompanies",
                table: "BusCompanies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusInfos_BusCompanies_CompanyId",
                table: "BusInfos",
                column: "CompanyId",
                principalTable: "BusCompanies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusInfos_BusCompanies_CompanyId",
                table: "BusInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusCompanies",
                table: "BusCompanies");

            migrationBuilder.RenameTable(
                name: "BusCompanies",
                newName: "BusCompany");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusCompany",
                table: "BusCompany",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusInfos_BusCompany_CompanyId",
                table: "BusInfos",
                column: "CompanyId",
                principalTable: "BusCompany",
                principalColumn: "Id");
        }
    }
}
