using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpanseTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedManagerRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63bdb1fc-ba46-4664-81d6-e667ccd75683");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "96910574-f9b8-4be8-a3ff-27e86906746e", null, "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2f29953-2efe-4b26-9a6b-1824e9163511",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c729e18d-3fe8-474b-9c3e-caa75fa3a936", "AQAAAAIAAYagAAAAELNQxOIvLijh2Gypuy7SEtD53Lv8+iKGmFCQfQxOVvqGwP4dcRTU032PgM5zovvv5g==", "19d5db37-ce09-48bf-80b9-38b59f35d65e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96910574-f9b8-4be8-a3ff-27e86906746e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63bdb1fc-ba46-4664-81d6-e667ccd75683", null, null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2f29953-2efe-4b26-9a6b-1824e9163511",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3fa7790-5483-4cfa-847e-56ce94ac2432", "AQAAAAIAAYagAAAAEApbxis1/DuOc17D2xj7aNmN1IjuJ6Nfd/7iZs03SDmxERW4/Le4eVeVeBn+ktFSRA==", "c25df407-e49b-4963-9341-4058a3b6f348" });
        }
    }
}
