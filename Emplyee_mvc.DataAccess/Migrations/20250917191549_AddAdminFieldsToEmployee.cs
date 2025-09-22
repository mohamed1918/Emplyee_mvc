using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emplyee_mvc.DataAccess.Migrations
{
    
    public partial class AddAdminFieldsToEmployee : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "Employees");
        }
    }
}
