using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalAtlas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ParentNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxonomyItems_TaxonomyItems_ParentId",
                table: "TaxonomyItems");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "TaxonomyItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxonomyItems_TaxonomyItems_ParentId",
                table: "TaxonomyItems",
                column: "ParentId",
                principalTable: "TaxonomyItems",
                principalColumn: "TaxonomyItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxonomyItems_TaxonomyItems_ParentId",
                table: "TaxonomyItems");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "TaxonomyItems",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxonomyItems_TaxonomyItems_ParentId",
                table: "TaxonomyItems",
                column: "ParentId",
                principalTable: "TaxonomyItems",
                principalColumn: "TaxonomyItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
