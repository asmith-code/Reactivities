using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) //adding the new migration - i.e. adding the table and column names
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false), 
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Venue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id); //Id has been made the primary key because of its name - nothing to do with its position in the list 
                });                                                 //- if Id was a different name it wouldn't have worked
        }

        protected override void Down(MigrationBuilder migrationBuilder) //going back to earlier migration - i.e. dropping the table that was created
        {
            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
