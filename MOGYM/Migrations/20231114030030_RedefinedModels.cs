using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOGYM.Migrations
{
    /// <inheritdoc />
    public partial class RedefinedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Admins_AdminModelId",
                table: "Trainers");

            migrationBuilder.RenameColumn(
                name: "AdminModelId",
                table: "Trainers",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Trainers_AdminModelId",
                table: "Trainers",
                newName: "IX_Trainers_AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Admins_AdminId",
                table: "Trainers",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Admins_AdminId",
                table: "Trainers");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Trainers",
                newName: "AdminModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Trainers_AdminId",
                table: "Trainers",
                newName: "IX_Trainers_AdminModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Admins_AdminModelId",
                table: "Trainers",
                column: "AdminModelId",
                principalTable: "Admins",
                principalColumn: "Id");
        }
    }
}
