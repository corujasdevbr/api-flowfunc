using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corujasdev.Flowfunc.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Table_Rule_Rule_Type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RuleType",
                table: "Rules",
                type: "VARCHAR(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RuleType",
                table: "Rules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)",
                oldNullable: true);
        }
    }
}
