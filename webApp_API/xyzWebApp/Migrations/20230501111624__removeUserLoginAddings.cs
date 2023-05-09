using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xyzWebApp.Migrations
{
    public partial class _removeUserLoginAddings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168d01bf-f3eb-49c5-8f52-35a05304c020",
                column: "ConcurrencyStamp",
                value: "10edf77d-4861-48c9-a1bf-dad6107a0fbd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a830b98-d453-441b-bf95-f97c7b79c81c",
                column: "ConcurrencyStamp",
                value: "ffbf3cdf-9940-4bc8-85ef-a640a239716d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7023ed45-9bf9-4fb8-a7e8-30378c89d14d",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "4bbff3f4-2d1e-4eeb-b90f-15b8533e6698", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEAumEt6n+poQgzYsXpOHpI5LoL+IUYxIA5/qJhFo9FI2GivhEdbiDja12bW33A2Rqg==", "3403f5b4-c01e-40af-a3f7-bcbaec9269bd", "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168d01bf-f3eb-49c5-8f52-35a05304c020",
                column: "ConcurrencyStamp",
                value: "f2c408b4-b83c-4bbc-9147-996eb9270204");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a830b98-d453-441b-bf95-f97c7b79c81c",
                column: "ConcurrencyStamp",
                value: "eba10eab-125d-4518-9f86-804ab746516e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7023ed45-9bf9-4fb8-a7e8-30378c89d14d",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "13a4bb1a-8704-440a-828c-eae8f6f287fc", "MASTER_ADMIN", "AQAAAAEAACcQAAAAENXMA9PYUOyO/2m/Yjk8YRcULwHaT2Aqybjo2c7EiXeFAKVhsQaDJmtVroUWsaeOJQ==", "046d50dd-5b78-46da-89a9-613cee456b82", "master_admin" });
        }
    }
}
