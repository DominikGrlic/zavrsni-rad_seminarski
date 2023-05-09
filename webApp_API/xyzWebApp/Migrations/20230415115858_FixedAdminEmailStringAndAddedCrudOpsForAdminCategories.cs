using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xyzWebApp.Migrations
{
    public partial class FixedAdminEmailStringAndAddedCrudOpsForAdminCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168d01bf-f3eb-49c5-8f52-35a05304c020",
                column: "ConcurrencyStamp",
                value: "80cc8b07-632b-4139-8536-8ff2507b46a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a830b98-d453-441b-bf95-f97c7b79c81c",
                column: "ConcurrencyStamp",
                value: "fcbf208c-6270-41a9-a638-536ee19fb25c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7023ed45-9bf9-4fb8-a7e8-30378c89d14d",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "23085651-4775-4e3f-aa12-ad2503a17727", "MASTER-ADMIN", "AQAAAAEAACcQAAAAELXrPJOTTGPHJoY5mJZLu8XWKIBMvhdroWMLVbNERJgKHJ+MaGHww/RzVGX781CDOA==", "4d6764c3-ef88-49eb-897b-aa991d9e014b", "master-admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168d01bf-f3eb-49c5-8f52-35a05304c020",
                column: "ConcurrencyStamp",
                value: "30aa1713-6e82-499c-a368-8cbc2059e068");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a830b98-d453-441b-bf95-f97c7b79c81c",
                column: "ConcurrencyStamp",
                value: "4312759b-deb2-4382-812b-47ff0f8f384c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7023ed45-9bf9-4fb8-a7e8-30378c89d14d",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "168b53e8-9e9f-4c85-b49f-0f5949f7bbee", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAELgK3wB9AyRPUlEtd43fNmsH0DLk6kHUpwEH2q5//FqdEYDtkNProC4QIa15FJngAw==", "23373dbd-a083-48a2-a2f7-59c580b23bdb", "admin@admin.com" });
        }
    }
}
