using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWebApp.Migrations
{
    /// <inheritdoc />
    public partial class removedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "existingItem",
                table: "InnovationIdeas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "existingItem",
                table: "InnovationIdeas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
