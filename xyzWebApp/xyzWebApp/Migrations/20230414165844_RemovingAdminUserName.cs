using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xyzWebApp.Migrations
{
    public partial class RemovingAdminUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168d01bf-f3eb-49c5-8f52-35a05304c020",
                column: "ConcurrencyStamp",
                value: "9ebc309c-eadc-4187-be73-972ebf1abee3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a830b98-d453-441b-bf95-f97c7b79c81c",
                column: "ConcurrencyStamp",
                value: "ed82fb33-654e-4371-9e34-0bc585f758cd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7023ed45-9bf9-4fb8-a7e8-30378c89d14d",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b2e5b6ae-e043-4c79-a452-68613aea4a86", "MASTER_ADMIN", "AQAAAAEAACcQAAAAECqBKkcDkbrC5SfMVZi2Sf+RS0UTk6oOslcWyvTRccC+Aebb5xi95CxmK04OaSO3hQ==", "cb780154-a9cd-4c29-bc95-f72f59a2b783", "master_admin" });
        }
    }
}
