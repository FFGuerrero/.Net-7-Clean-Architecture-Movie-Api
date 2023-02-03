﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Infrastructure.Migrations;

/// <inheritdoc />
public partial class CreateMovieSale : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "MovieSales",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                MovieId = table.Column<int>(type: "int", nullable: false),
                UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MovieSales", x => x.Id);
                table.ForeignKey(
                    name: "FK_MovieSales_Movies_MovieId",
                    column: x => x.MovieId,
                    principalTable: "Movies",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_MovieSales_MovieId",
            table: "MovieSales",
            column: "MovieId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "MovieSales");
    }
}