using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalAtlas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntityBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TaxonomyItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "TaxonomyItems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedUtc",
                table: "TaxonomyItems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "TaxonomyItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedUtc",
                table: "TaxonomyItems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TaxonomyGroups",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "TaxonomyGroups",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedUtc",
                table: "TaxonomyGroups",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "TaxonomyGroups",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedUtc",
                table: "TaxonomyGroups",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TaxonomyItems");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "TaxonomyItems");

            migrationBuilder.DropColumn(
                name: "DeletedUtc",
                table: "TaxonomyItems");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "TaxonomyItems");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUtc",
                table: "TaxonomyItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TaxonomyGroups");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "TaxonomyGroups");

            migrationBuilder.DropColumn(
                name: "DeletedUtc",
                table: "TaxonomyGroups");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "TaxonomyGroups");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUtc",
                table: "TaxonomyGroups");
        }
    }
}
