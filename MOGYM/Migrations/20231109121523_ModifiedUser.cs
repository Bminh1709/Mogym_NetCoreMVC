using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOGYM.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Trainers_TrainerId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTables_Trainers_TrainerId",
                table: "TimeTables");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Admins_AdminId",
                table: "Trainers");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Branches_BranchId",
                table: "Trainers");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSchedules_Trainees_TraineeId",
                table: "WorkoutSchedules");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers");

            migrationBuilder.RenameTable(
                name: "Trainers",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_Trainers_BranchId",
                table: "Users",
                newName: "IX_Users_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Trainers_AdminId",
                table: "Users",
                newName: "IX_Users_AdminId");

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Admin_BranchId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Trainee_BranchId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_BranchId",
                table: "Services",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Admin_BranchId",
                table: "Users",
                column: "Admin_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Trainee_BranchId",
                table: "Users",
                column: "Trainee_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TrainerId",
                table: "Users",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Users_TrainerId",
                table: "Feedbacks",
                column: "TrainerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Branches_BranchId",
                table: "Services",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTables_Users_TrainerId",
                table: "TimeTables",
                column: "TrainerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Branches_Admin_BranchId",
                table: "Users",
                column: "Admin_BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Branches_BranchId",
                table: "Users",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Branches_Trainee_BranchId",
                table: "Users",
                column: "Trainee_BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_AdminId",
                table: "Users",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_TrainerId",
                table: "Users",
                column: "TrainerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSchedules_Users_TraineeId",
                table: "WorkoutSchedules",
                column: "TraineeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Users_TrainerId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Branches_BranchId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTables_Users_TrainerId",
                table: "TimeTables");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Branches_Admin_BranchId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Branches_BranchId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Branches_Trainee_BranchId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_AdminId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_TrainerId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSchedules_Users_TraineeId",
                table: "WorkoutSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Services_BranchId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Admin_BranchId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Trainee_BranchId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TrainerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Admin_BranchId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Trainee_BranchId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Trainers");

            migrationBuilder.RenameIndex(
                name: "IX_Users_BranchId",
                table: "Trainers",
                newName: "IX_Trainers_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AdminId",
                table: "Trainers",
                newName: "IX_Trainers_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    TrainerId = table.Column<int>(type: "int", nullable: true),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainees_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trainees_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_BranchId",
                table: "Admins",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_BranchId",
                table: "Trainees",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_TrainerId",
                table: "Trainees",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Trainers_TrainerId",
                table: "Feedbacks",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTables_Trainers_TrainerId",
                table: "TimeTables",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Admins_AdminId",
                table: "Trainers",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Branches_BranchId",
                table: "Trainers",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSchedules_Trainees_TraineeId",
                table: "WorkoutSchedules",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
