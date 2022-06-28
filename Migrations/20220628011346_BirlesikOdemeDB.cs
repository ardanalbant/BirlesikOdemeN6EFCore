using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BirlesikOdemeN6EFCore.Migrations
{
    public partial class BirlesikOdemeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SURNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BIRTHDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDENTITYNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDENTITYNOVERIFIED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EKLZMN = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EKLKLN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GNCZMN = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GNCKLN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
