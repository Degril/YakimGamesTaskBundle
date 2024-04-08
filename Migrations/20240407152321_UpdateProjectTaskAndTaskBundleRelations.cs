﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YakimGamesTaskBundle.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProjectTaskAndTaskBundleRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "TaskItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskItems",
                table: "TaskItems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TaskBundles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskBundles", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskTaskBundle");

            migrationBuilder.DropTable(
                name: "TaskBundles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskItems",
                table: "TaskItems");

            migrationBuilder.RenameTable(
                name: "TaskItems",
                newName: "Tasks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");
        }
    }
}
