using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaApp.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddSaltToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Salt",
                table: "Accounts",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Accounts");
        }
    }
}
