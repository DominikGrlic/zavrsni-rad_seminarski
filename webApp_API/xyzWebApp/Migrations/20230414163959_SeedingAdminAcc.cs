using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xyzWebApp.Migrations
{
    public partial class SeedingAdminAcc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168d01bf-f3eb-49c5-8f52-35a05304c020",
                column: "ConcurrencyStamp",
                value: "e3c438f3-e85f-43e6-9ede-6d0f1be8d5c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a830b98-d453-441b-bf95-f97c7b79c81c",
                column: "ConcurrencyStamp",
                value: "e7f31ee4-9b4d-4fee-964c-d94f22148a59");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7023ed45-9bf9-4fb8-a7e8-30378c89d14d", 0, "Slijepa ulica 8", "a8406642-00db-41a6-b597-99a8427ea064", "master@admin.com", false, "Red", "Pill", false, null, "MASTER@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEP2eCf6x01mVL0xDnW+c3BjZ2QNCvLKkx/rwULuozZlwuUkyMiNgZ/RlWQfBJZmCRQ==", null, false, "4ca7e2c5-a8d6-41de-9a41-d34d117f3d28", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7a830b98-d453-441b-bf95-f97c7b79c81c", "7023ed45-9bf9-4fb8-a7e8-30378c89d14d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7a830b98-d453-441b-bf95-f97c7b79c81c", "7023ed45-9bf9-4fb8-a7e8-30378c89d14d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7023ed45-9bf9-4fb8-a7e8-30378c89d14d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168d01bf-f3eb-49c5-8f52-35a05304c020",
                column: "ConcurrencyStamp",
                value: "e9cf0fe0-85c3-4c56-ab3c-dc0686375305");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a830b98-d453-441b-bf95-f97c7b79c81c",
                column: "ConcurrencyStamp",
                value: "7b31e4b3-16ce-4d5e-b01e-c427c108df04");
        }
    }
}
