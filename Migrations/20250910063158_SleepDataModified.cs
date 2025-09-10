using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneHelper.Migrations
{
    /// <inheritdoc />
    public partial class SleepDataModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "SleepLogs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "SleepLogs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "SleepLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "SleepLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
