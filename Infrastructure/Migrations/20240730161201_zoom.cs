using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Todo2.Migrations
{
    /// <inheritdoc />
    public partial class zoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    taskNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    taskDue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    done = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.taskNum);
                });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "taskNum", "done", "taskDue", "taskName" },
                values: new object[,]
                {
                    { 1, false, "3/8/2024", "2022 Exam" },
                    { 2, false, "12/8/2024", "Finish angular videos" },
                    { 3, false, "15/8/2024", "Change gym workout routine" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");
        }
    }
}
