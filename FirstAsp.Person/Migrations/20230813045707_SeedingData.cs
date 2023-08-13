using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstAsp.Person.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "NationalCode", "LastName", "Name" },
                values: new object[,]
                {
                    { 123456789, "Sadeqi", "Reza" },
                    { 987654321, "Smith", "Moana" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "NationalCode",
                keyValue: 123456789);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "NationalCode",
                keyValue: 987654321);
        }
    }
}
