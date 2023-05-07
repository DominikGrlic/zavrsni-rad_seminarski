using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xyzWebApp.Migrations
{
    public partial class _newDbFinalDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168d01bf-f3eb-49c5-8f52-35a05304c020",
                column: "ConcurrencyStamp",
                value: "f1907d22-c43d-4e41-a191-13ced8e50306");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a830b98-d453-441b-bf95-f97c7b79c81c",
                column: "ConcurrencyStamp",
                value: "91a126ea-8e75-4804-a21c-60405c49cfbe");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7023ed45-9bf9-4fb8-a7e8-30378c89d14d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e3b36a8-9ca1-40e5-89fc-cac37f8652e7", "AQAAAAEAACcQAAAAEOQPvIImwWznZtjUFzqOjqnZdarElw7bjix0OiCREYJV0l/ZshuNeWidT9o4sb1Qnw==", "bfe3457f-8f67-48ad-80ef-2b143bf4c04a" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Massage's we offer.", "Massage's" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Title" },
                values: new object[] { 6, "Natural ingeredient toothpaste's made by hand.", null, "Toothpaste's" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 2, 2 },
                    { 3, 2, 9 },
                    { 4, 3, 3 },
                    { 5, 3, 4 },
                    { 6, 3, 5 },
                    { 7, 3, 11 },
                    { 8, 4, 6 },
                    { 9, 4, 7 },
                    { 10, 4, 12 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "bergam_oil.jpg");

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "CategoryId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Image", "Title" },
                values: new object[] { "reflexo.jpg", "Reflexo therapy" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "wome_mass.jpg");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Image", "Title" },
                values: new object[] { "dry_needle.jpg", "Dry needle therapy" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[] { 11, 6, 8 });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[] { 12, 6, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168d01bf-f3eb-49c5-8f52-35a05304c020",
                column: "ConcurrencyStamp",
                value: "c4767237-7dec-4a51-b5dc-ecf98ebec354");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a830b98-d453-441b-bf95-f97c7b79c81c",
                column: "ConcurrencyStamp",
                value: "239a39a8-594f-4345-94ff-4e99b2f9249d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7023ed45-9bf9-4fb8-a7e8-30378c89d14d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c16e1928-4d3a-472d-962e-7aa53e9eddf2", "AQAAAAEAACcQAAAAELWIlhKU4TGc4E71G50MRmf8uxWdC0ou2Q0/L3vNbA9wW2sJ+LK/l3bQaoIARyGc4w==", "5654e3cf-9624-424b-ab1e-ea807b22881a" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Offer of our massage's.", "Massage" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "bergam-oil.jpg");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Image", "Title" },
                values: new object[] { null, "Men's sports massage" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Image", "Title" },
                values: new object[] { null, "Maderotherapy" });
        }
    }
}
