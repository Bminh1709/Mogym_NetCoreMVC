using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOGYM.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedUserBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Branches_BranchId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Branches_BranchId",
                table: "Trainees");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Branches_BranchId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_BranchId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_BranchId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Admins_BranchId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Admins");

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchId",
                table: "Users",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Branches_BranchId",
                table: "Users",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Branches_BranchId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BranchId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Trainers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Trainees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Admins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_BranchId",
                table: "Trainers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_BranchId",
                table: "Trainees",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_BranchId",
                table: "Admins",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Branches_BranchId",
                table: "Admins",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Branches_BranchId",
                table: "Trainees",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Branches_BranchId",
                table: "Trainers",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");
        }
    }
}
