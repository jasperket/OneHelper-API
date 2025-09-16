using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneHelper.Migrations
{
    /// <inheritdoc />
    public partial class addedEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ToDos_Title",
                table: "ToDos");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_Title",
                table: "ToDos",
                column: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ToDos_Title",
                table: "ToDos");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_Title",
                table: "ToDos",
                column: "Title",
                unique: true);
        }
    }
}
