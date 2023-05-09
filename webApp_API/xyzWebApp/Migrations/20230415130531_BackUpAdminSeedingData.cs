using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xyzWebApp.Migrations
{
    public partial class BackUpAdminSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168d01bf-f3eb-49c5-8f52-35a05304c020",
                column: "ConcurrencyStamp",
                value: "5bb8cd23-6c0a-4548-acdb-3281ccc3ec7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a830b98-d453-441b-bf95-f97c7b79c81c",
                column: "ConcurrencyStamp",
                value: "4488b28c-3738-40de-adbb-83d91b551a13");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7023ed45-9bf9-4fb8-a7e8-30378c89d14d",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "31e239ca-071e-4f1c-8720-e69586b830ed", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEEUlMsfWqdDwJv+YwvTgPXbOKBzlRrpb39ivPKjEJNo6Z0uYnFiOsgU6mQTd/HVUXw==", "6a884f01-158c-43f7-9f46-a54d3ef6d042", "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
