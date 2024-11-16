using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWebApp.Migrations
{
    /// <inheritdoc />
    public partial class CorrectColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "InnovationIdeas",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "implemented",
                table: "InnovationIdeas",
                newName: "Implemented");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "InnovationIdeas",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "InnovationIdeas",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "InnovationIdeas",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "InnovationIdeas",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Implemented",
                table: "InnovationIdeas",
                newName: "implemented");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "InnovationIdeas",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "InnovationIdeas",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InnovationIdeas",
                newName: "id");
        }
    }
}
