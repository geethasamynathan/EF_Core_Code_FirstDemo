using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_Code_FirstDemo.Migrations
{
    /// <inheritdoc />
    public partial class columnnamechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeName",
                table: "Employees",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "EmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "EmployeeName");

            migrationBuilder.RenameColumn(
                name: "EmpId",
                table: "Employees",
                newName: "EmployeeId");
        }
    }
}
