using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xyzWebApp.Migrations
{
    public partial class ChangingAdminEmailAndPass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168d01bf-f3eb-49c5-8f52-35a05304c020",
                column: "ConcurrencyStamp",
                value: "e8badc97-ee72-44fc-b059-a552a8d21751");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a830b98-d453-441b-bf95-f97c7b79c81c",
                column: "ConcurrencyStamp",
                value: "83b51ed9-a4fd-4139-9be5-e1761cf44d27");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7023ed45-9bf9-4fb8-a7e8-30378c89d14d",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "eafee2b2-0f08-4c55-96bf-129a770e7164", "admin@admin.com", "Master", "Admin", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEDu8FuhM7+VgRbbYwCvcq/ViJ1DRSB/JeFQiHLq4+jxVYjaygqsSNWtfsLXX9mZqdA==", "df4da4c3-96bd-43ee-ab1a-072e85dfdd56", "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7023ed45-9bf9-4fb8-a7e8-30378c89d14d",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a8406642-00db-41a6-b597-99a8427ea064", "master@admin.com", "Red", "Pill", "MASTER@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEP2eCf6x01mVL0xDnW+c3BjZ2QNCvLKkx/rwULuozZlwuUkyMiNgZ/RlWQfBJZmCRQ==", "4ca7e2c5-a8d6-41de-9a41-d34d117f3d28", "admin" });
        }
    }
}
