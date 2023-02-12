using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Infrastructure.Migrations;

/// <inheritdoc />
public partial class CreateMovieRent : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "MovieRentalPlans",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                DurationInDays = table.Column<int>(type: "int", nullable: false),
                PenaltyAmount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                IsAvailable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MovieRentalPlans", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "MovieRentals",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                MovieId = table.Column<int>(type: "int", nullable: false),
                UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                MovieRentalPlanId = table.Column<int>(type: "int", nullable: false),
                Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                PenaltyAmount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                ReturnedOnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                PaidPenaltyAmount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MovieRentals", x => x.Id);
                table.ForeignKey(
                    name: "FK_MovieRentals_MovieRentalPlans_MovieRentalPlanId",
                    column: x => x.MovieRentalPlanId,
                    principalTable: "MovieRentalPlans",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_MovieRentals_Movies_MovieId",
                    column: x => x.MovieId,
                    principalTable: "Movies",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_MovieRentals_MovieId",
            table: "MovieRentals",
            column: "MovieId");

        migrationBuilder.CreateIndex(
            name: "IX_MovieRentals_MovieRentalPlanId",
            table: "MovieRentals",
            column: "MovieRentalPlanId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "MovieRentals");

        migrationBuilder.DropTable(
            name: "MovieRentalPlans");
    }
}