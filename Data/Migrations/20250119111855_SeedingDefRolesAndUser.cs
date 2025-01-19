using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpanseTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefRolesAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d319d52-8efa-41d3-a0e2-10aebf0551f8", null, "Admin", "ADMIN" },
                    { "5a3a3f9a-889b-47fe-98f5-15d876e93f7b", null, "User", "NAME" },
                    { "8588ace6-298b-43de-b6ee-7808d087dde8", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d2f29953-2efe-4b26-9a6b-1824e9163511", 0, "804cc74c-419c-4c30-9351-62c6e1cfaab7", "admin@locahost.com", true, false, null, "ADMIN@LOCAHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAENxzuueowmYD9Q2QHNYqR4KIautC9o+nJ6OmGXq5hHcGTfHRve0QvQaMG0zfj62KjQ==", null, false, "eea36a83-9168-4a8a-8cab-1bcf97a62823", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0d319d52-8efa-41d3-a0e2-10aebf0551f8", "d2f29953-2efe-4b26-9a6b-1824e9163511" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a3a3f9a-889b-47fe-98f5-15d876e93f7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8588ace6-298b-43de-b6ee-7808d087dde8");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0d319d52-8efa-41d3-a0e2-10aebf0551f8", "d2f29953-2efe-4b26-9a6b-1824e9163511" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d319d52-8efa-41d3-a0e2-10aebf0551f8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2f29953-2efe-4b26-9a6b-1824e9163511");
        }
    }
}
