using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddColumnsForMovieTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "Availability",
            table: "Movies",
            newName: "IsAvailableForSale");

        migrationBuilder.AddColumn<bool>(
            name: "IsAvailableForRental",
            table: "Movies",
            type: "bit",
            nullable: false,
            defaultValue: false);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "IsAvailableForRental",
            table: "Movies");

        migrationBuilder.RenameColumn(
            name: "IsAvailableForSale",
            table: "Movies",
            newName: "Availability");
    }
}