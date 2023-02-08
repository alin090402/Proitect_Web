using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkForever.Migrations
{
    /// <inheritdoc />
    public partial class WorkRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastWorked",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    MoneyEarned = table.Column<double>(type: "float", nullable: false),
                    ItemsEarned = table.Column<int>(type: "int", nullable: false),
                    WorkedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkRecords_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkRecords_FactoryId",
                table: "WorkRecords",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkRecords_UserId",
                table: "WorkRecords",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkRecords");

            migrationBuilder.DropColumn(
                name: "LastWorked",
                table: "Users");
        }
    }
}
