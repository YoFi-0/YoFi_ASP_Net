using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YofiASPNet.Migrations
{
    /// <inheritdoc />
    public partial class Mame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordConfirmed",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordConfirmed",
                table: "Users");
        }
    }
}
