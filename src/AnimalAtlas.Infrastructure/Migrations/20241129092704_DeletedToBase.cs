using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalAtlas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeletedToBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "TaxonomyItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "TaxonomyGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "TaxonomyItems");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "TaxonomyGroups");
        }
    }
}
