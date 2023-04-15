using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xyzWebApp.Migrations
{
    public partial class AddingAdminUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "eafee2b2-0f08-4c55-96bf-129a770e7164", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEDu8FuhM7+VgRbbYwCvcq/ViJ1DRSB/JeFQiHLq4+jxVYjaygqsSNWtfsLXX9mZqdA==", "df4da4c3-96bd-43ee-ab1a-072e85dfdd56", "admin@admin.com" });
        }
    }
}
