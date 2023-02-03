using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Infrastructure.Migrations;

/// <inheritdoc />
public partial class CreateMovieRental : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "MovieRental",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                MovieId = table.Column<int>(type: "int", nullable: false),
                UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                MovieRentalPlanId = table.Column<int>(type: "int", nullable: false),
                Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                PenaltyAmount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MovieRental", x => x.Id);
                table.ForeignKey(
                    name: "FK_MovieRental_MovieRentalPlans_MovieRentalPlanId",
                    column: x => x.MovieRentalPlanId,
                    principalTable: "MovieRentalPlans",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_MovieRental_Movies_MovieId",
                    column: x => x.MovieId,
                    principalTable: "Movies",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_MovieRental_MovieId",
            table: "MovieRental",
            column: "MovieId");

        migrationBuilder.CreateIndex(
            name: "IX_MovieRental_MovieRentalPlanId",
            table: "MovieRental",
            column: "MovieRentalPlanId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "MovieRental");
    }
}
