using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YakimGamesTaskBundle.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletionCriteria",
                table: "TaskItems");

            migrationBuilder.AddColumn<int>(
                name: "CurrentProgress",
                table: "TaskItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgressGoal",
                table: "TaskItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentProgress",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "ProgressGoal",
                table: "TaskItems");

            migrationBuilder.AddColumn<string>(
                name: "CompletionCriteria",
                table: "TaskItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
