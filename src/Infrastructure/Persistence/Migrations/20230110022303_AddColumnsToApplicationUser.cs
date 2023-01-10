using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Infrastructure.Persistence.Migrations;

/// <inheritdoc />
public partial class AddColumnsToApplicationUser : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<DateTime>(
            name: "DateOfBirth",
            table: "AspNetUsers",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "LastName",
            table: "AspNetUsers",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Name",
            table: "AspNetUsers",
            type: "nvarchar(max)",
            nullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "DateOfBirth",
            table: "AspNetUsers");

        migrationBuilder.DropColumn(
            name: "LastName",
            table: "AspNetUsers");

        migrationBuilder.DropColumn(
            name: "Name",
            table: "AspNetUsers");
    }
}
