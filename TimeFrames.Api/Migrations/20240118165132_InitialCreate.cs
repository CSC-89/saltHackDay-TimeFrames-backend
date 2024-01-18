using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeFrames.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DayData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkTime = table.Column<double>(type: "float", nullable: false),
                    WakeTime = table.Column<double>(type: "float", nullable: false),
                    SleepTime = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayData_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletionTime = table.Column<int>(type: "int", nullable: false),
                    TaskType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDo_DayData_DayDataId",
                        column: x => x.DayDataId,
                        principalTable: "DayData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayData_UserId",
                table: "DayData",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_DayDataId",
                table: "ToDo",
                column: "DayDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDo");

            migrationBuilder.DropTable(
                name: "DayData");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
