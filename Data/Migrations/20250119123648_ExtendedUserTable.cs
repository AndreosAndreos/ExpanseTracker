using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpanseTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8588ace6-298b-43de-b6ee-7808d087dde8");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63bdb1fc-ba46-4664-81d6-e667ccd75683", null, null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2f29953-2efe-4b26-9a6b-1824e9163511",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3fa7790-5483-4cfa-847e-56ce94ac2432", new DateOnly(1950, 12, 19), "Default", "Admin", "AQAAAAIAAYagAAAAEApbxis1/DuOc17D2xj7aNmN1IjuJ6Nfd/7iZs03SDmxERW4/Le4eVeVeBn+ktFSRA==", "c25df407-e49b-4963-9341-4058a3b6f348" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63bdb1fc-ba46-4664-81d6-e667ccd75683");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8588ace6-298b-43de-b6ee-7808d087dde8", null, null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2f29953-2efe-4b26-9a6b-1824e9163511",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "804cc74c-419c-4c30-9351-62c6e1cfaab7", "AQAAAAIAAYagAAAAENxzuueowmYD9Q2QHNYqR4KIautC9o+nJ6OmGXq5hHcGTfHRve0QvQaMG0zfj62KjQ==", "eea36a83-9168-4a8a-8cab-1bcf97a62823" });
        }
    }
}
