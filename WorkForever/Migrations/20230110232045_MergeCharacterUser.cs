using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkForever.Migrations
{
    /// <inheritdoc />
    public partial class MergeCharacterUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factories_Characters_CharacterId",
                table: "Factories");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Factories_CharacterId",
                table: "Factories");

            migrationBuilder.RenameColumn(
                name: "FactoryType",
                table: "Factories",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FactoryLevel",
                table: "Factories",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "Factories",
                newName: "Level");

            migrationBuilder.AddColumn<double>(
                name: "WorkExperience",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Factories_UserId",
                table: "Factories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factories_Users_UserId",
                table: "Factories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factories_Users_UserId",
                table: "Factories");

            migrationBuilder.DropIndex(
                name: "IX_Factories_UserId",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "WorkExperience",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Factories",
                newName: "FactoryType");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Factories",
                newName: "FactoryLevel");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Factories",
                newName: "CharacterId");

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkExperience = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factories_CharacterId",
                table: "Factories",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factories_Characters_CharacterId",
                table: "Factories",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
