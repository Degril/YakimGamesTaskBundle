using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YakimGamesTaskBundle.Migrations
{
    /// <inheritdoc />
    public partial class FixBundleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BundleId1",
                table: "TaskItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_BundleId1",
                table: "TaskItems",
                column: "BundleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_TaskBundles_BundleId1",
                table: "TaskItems",
                column: "BundleId1",
                principalTable: "TaskBundles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_TaskBundles_BundleId1",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_BundleId1",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "BundleId1",
                table: "TaskItems");
        }
    }
}
