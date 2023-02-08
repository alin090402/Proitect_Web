using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkForever.Migrations
{
    /// <inheritdoc />
    public partial class UserInfoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoUser_Users_UserId",
                table: "InfoUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InfoUser",
                table: "InfoUser");

            migrationBuilder.RenameTable(
                name: "InfoUser",
                newName: "InfoUsers");

            migrationBuilder.RenameIndex(
                name: "IX_InfoUser_UserId",
                table: "InfoUsers",
                newName: "IX_InfoUsers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InfoUsers",
                table: "InfoUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoUsers_Users_UserId",
                table: "InfoUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoUsers_Users_UserId",
                table: "InfoUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InfoUsers",
                table: "InfoUsers");

            migrationBuilder.RenameTable(
                name: "InfoUsers",
                newName: "InfoUser");

            migrationBuilder.RenameIndex(
                name: "IX_InfoUsers_UserId",
                table: "InfoUser",
                newName: "IX_InfoUser_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InfoUser",
                table: "InfoUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoUser_Users_UserId",
                table: "InfoUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
