using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itzz.Data
{
    /// <inheritdoc />
    public partial class RouteEntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderLoc",
                table: "Routes",
                newName: "StorageLoc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StorageLoc",
                table: "Routes",
                newName: "SenderLoc");
        }
    }
}
