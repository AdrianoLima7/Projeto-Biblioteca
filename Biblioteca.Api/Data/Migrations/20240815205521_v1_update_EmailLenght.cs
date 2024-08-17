using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Api.Migrations
{
    /// <inheritdoc />
    public partial class v1_update_EmailLenght : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Usuario",
                type: "NVARCHAR(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuario",
                type: "NVARCHAR(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Usuario",
                type: "NVARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuario",
                type: "NVARCHAR",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
