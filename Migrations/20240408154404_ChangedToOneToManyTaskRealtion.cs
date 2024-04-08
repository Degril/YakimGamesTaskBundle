using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YakimGamesTaskBundle.Migrations
{
    /// <inheritdoc />
    public partial class ChangedToOneToManyTaskRealtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskTaskBundle");

            migrationBuilder.AddColumn<int>(
                name: "BundleId",
                table: "TaskItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_BundleId",
                table: "TaskItems",
                column: "BundleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_TaskBundles_BundleId",
                table: "TaskItems",
                column: "BundleId",
                principalTable: "TaskBundles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_TaskBundles_BundleId",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_BundleId",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "BundleId",
                table: "TaskItems");

            migrationBuilder.CreateTable(
                name: "TaskTaskBundle",
                columns: table => new
                {
                    TaskBundlesId = table.Column<int>(type: "INTEGER", nullable: false),
                    TasksId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTaskBundle", x => new { x.TaskBundlesId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_TaskTaskBundle_TaskBundles_TaskBundlesId",
                        column: x => x.TaskBundlesId,
                        principalTable: "TaskBundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskTaskBundle_TaskItems_TasksId",
                        column: x => x.TasksId,
                        principalTable: "TaskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskTaskBundle_TasksId",
                table: "TaskTaskBundle",
                column: "TasksId");
        }
    }
}
