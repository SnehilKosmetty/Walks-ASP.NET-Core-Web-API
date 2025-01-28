using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Walks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9f9833a2-bc3e-44fe-8151-60986a51ac1c"), "Medium" },
                    { new Guid("cf95d327-3650-45c2-b9a4-2e4ba3df9557"), "Easy" },
                    { new Guid("e2dff0f8-488b-40bf-b48e-3fdbd4435424"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("c3005489-95f7-41b3-8ecb-0677947df9b1"), "BOP", "Bay of Plenty", null },
                    { new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "STL", "Southland", null },
                    { new Guid("f683c31c-bc63-477f-8335-2b6d31133dc9"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f9abf4e7-726d-40b0-bff5-edbb7b79a280"), "NTL", "Northland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9f9833a2-bc3e-44fe-8151-60986a51ac1c"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cf95d327-3650-45c2-b9a4-2e4ba3df9557"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e2dff0f8-488b-40bf-b48e-3fdbd4435424"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c3005489-95f7-41b3-8ecb-0677947df9b1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f683c31c-bc63-477f-8335-2b6d31133dc9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f9abf4e7-726d-40b0-bff5-edbb7b79a280"));
        }
    }
}
