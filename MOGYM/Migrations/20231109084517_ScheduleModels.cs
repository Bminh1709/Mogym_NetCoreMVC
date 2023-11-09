using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOGYM.Migrations
{
    /// <inheritdoc />
    public partial class ScheduleModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    MarkedTime = table.Column<int>(type: "int", nullable: false),
                    CurrentWeek = table.Column<int>(type: "int", nullable: false),
                    Task = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTables_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    CurrentWeek = table.Column<int>(type: "int", nullable: false),
                    Task = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TraineeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutSchedules_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_TrainerId",
                table: "TimeTables",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSchedules_TraineeId",
                table: "WorkoutSchedules",
                column: "TraineeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeTables");

            migrationBuilder.DropTable(
                name: "WorkoutSchedules");
        }
    }
}
