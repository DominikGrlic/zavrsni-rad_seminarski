using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xyzWebApp.Migrations
{
    public partial class _fixingUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168d01bf-f3eb-49c5-8f52-35a05304c020",
                column: "ConcurrencyStamp",
                value: "bbb8f272-a8fc-459e-99f7-12b05772d6b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a830b98-d453-441b-bf95-f97c7b79c81c",
                column: "ConcurrencyStamp",
                value: "7cbccfc7-b504-4eda-b59b-8b27eb81d832");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7023ed45-9bf9-4fb8-a7e8-30378c89d14d",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "4948b441-6137-4d20-ab57-3b74b03be11d", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEJLuMzWg4VMgFUzooLx91Ss+fnZQ0cFdsia/mGZ/Nr/ge0W/W74ZiZIOscuvfrq5sQ==", "dfff6ef9-0f39-4dad-8d9d-c4822d06e1da", "admin@admin.com" });
        }
    }
}
