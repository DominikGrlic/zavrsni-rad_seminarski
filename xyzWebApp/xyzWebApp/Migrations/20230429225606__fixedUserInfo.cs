using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xyzWebApp.Migrations
{
    public partial class _fixedUserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "Address", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "Slijepa ulica 8", "31e239ca-071e-4f1c-8720-e69586b830ed", "AQAAAAEAACcQAAAAEEUlMsfWqdDwJv+YwvTgPXbOKBzlRrpb39ivPKjEJNo6Z0uYnFiOsgU6mQTd/HVUXw==", "6a884f01-158c-43f7-9f46-a54d3ef6d042" });
        }
    }
}
