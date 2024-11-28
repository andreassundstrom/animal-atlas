using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnimalAtlas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxonomyGroups",
                columns: table => new
                {
                    TaxonomyGroupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaxonomyGroupName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxonomyGroups", x => x.TaxonomyGroupId);
                });

            migrationBuilder.CreateTable(
                name: "TaxonomyItems",
                columns: table => new
                {
                    TaxonomyItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaxonomyItemName = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxonomyItems", x => x.TaxonomyItemId);
                    table.ForeignKey(
                        name: "FK_TaxonomyItems_TaxonomyGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "TaxonomyGroups",
                        principalColumn: "TaxonomyGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxonomyItems_TaxonomyItems_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TaxonomyItems",
                        principalColumn: "TaxonomyItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxonomyItems_GroupId",
                table: "TaxonomyItems",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxonomyItems_ParentId",
                table: "TaxonomyItems",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxonomyItems");

            migrationBuilder.DropTable(
                name: "TaxonomyGroups");
        }
    }
}
