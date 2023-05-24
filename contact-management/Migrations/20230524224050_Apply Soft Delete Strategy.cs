using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contact_management.Migrations
{
    /// <inheritdoc />
    public partial class ApplySoftDeleteStrategy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Contacts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Contacts");
        }
    }
}
