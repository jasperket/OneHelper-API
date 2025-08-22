using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OneHelper.Migrations
{
    /// <inheritdoc />
    public partial class updateMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "Gender", "Height", "LastName", "Password", "PhoneNumber", "Username", "Weight" },
                values: new object[,]
                {
                    { 1, new DateOnly(9999, 12, 31), "norwen@gmail.com", "Norwen", "Male", 1.71m, "Penas", "12345678", "0997", "wen", 151.7m },
                    { 2, new DateOnly(1, 1, 1), "kenneth@gmail.com", "kenneth", "Male", 1.71m, "Amodia", "12345678", "0997", "neth", 151.7m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
