﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xyzWebApp.Migrations
{
    public partial class _userModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4948b441-6137-4d20-ab57-3b74b03be11d", "AQAAAAEAACcQAAAAEJLuMzWg4VMgFUzooLx91Ss+fnZQ0cFdsia/mGZ/Nr/ge0W/W74ZiZIOscuvfrq5sQ==", "dfff6ef9-0f39-4dad-8d9d-c4822d06e1da" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168d01bf-f3eb-49c5-8f52-35a05304c020",
                column: "ConcurrencyStamp",
                value: "64e59712-dc5c-4845-87df-00f84c282234");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a830b98-d453-441b-bf95-f97c7b79c81c",
                column: "ConcurrencyStamp",
                value: "14edd72e-af78-4e34-ad41-30f70d9902ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7023ed45-9bf9-4fb8-a7e8-30378c89d14d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7166b85-842f-4ce3-bdff-ce13fc000d19", "AQAAAAEAACcQAAAAEISNGiwiGkbar/CoUi/D52GPUW0VAEbc8mpoNkFIPisXingO8GZ1+jNRPoEC9IHbSQ==", "29a0784b-828d-4355-83be-f7085b993832" });
        }
    }
}
