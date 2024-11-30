using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalAtlas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UniqueExternalIdUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_ExternalId",
                table: "Users",
                column: "ExternalId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_ExternalId",
                table: "Users");
        }
    }
}
