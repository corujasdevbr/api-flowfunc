using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corujasdev.Flowfunc.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Table_Rule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rules");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Rules",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Rules");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rules",
                type: "VARCHAR(255)",
                nullable: false,
                defaultValue: "");
        }
    }
}
