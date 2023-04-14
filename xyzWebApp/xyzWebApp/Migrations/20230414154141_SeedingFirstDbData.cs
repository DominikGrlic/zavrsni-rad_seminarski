using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xyzWebApp.Migrations
{
    public partial class SeedingFirstDbData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Services",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Title" },
                values: new object[,]
                {
                    { 1, null, null, "Masaže" },
                    { 2, null, null, "Ulja" },
                    { 3, null, null, "Sapuni" },
                    { 4, null, null, "Kreme" },
                    { 5, null, null, "Šamponi" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "InStock", "Price", "Sku", "Title" },
                values: new object[,]
                {
                    { 1, null, null, 54m, 39.99m, "MU0023", "Ulje za masažu" },
                    { 2, null, null, 46m, 47.99m, "EU0202", "Eterično ulje" },
                    { 3, null, null, 191m, 14.99m, "MO1002", "Miris za ormar na bazi sapuna" },
                    { 4, null, null, 201m, 4.99m, "SP2220", "Prirodni sapun" },
                    { 5, null, null, 98m, 29.99m, "FC0099", "Krema za lice" },
                    { 6, null, null, 81m, 24.99m, "SH0001", "Krema za suhu kožu" },
                    { 7, null, null, 39m, 3.49m, "MS7770", "Muški gel za tuširanje na bazi vetivera" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Image", "Price", "Sku", "Title" },
                values: new object[,]
                {
                    { 1, null, null, 29.99m, "SM2902", "Muška sportska masaža" },
                    { 2, null, null, 39.99m, "MC2222", "Ženska masaža cijelog tijela" },
                    { 3, null, null, 44.99m, "MM0440", "Maderoterapija" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Services",
                type: "ntext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "ntext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "ntext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);
        }
    }
}
