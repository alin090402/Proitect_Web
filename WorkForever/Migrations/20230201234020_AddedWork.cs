using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkForever.Migrations
{
    /// <inheritdoc />
    public partial class AddedWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Money",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ItemCreatedId",
                table: "Factories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Factories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Factories_ItemCreatedId",
                table: "Factories",
                column: "ItemCreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factories_Items_ItemCreatedId",
                table: "Factories",
                column: "ItemCreatedId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factories_Items_ItemCreatedId",
                table: "Factories");

            migrationBuilder.DropIndex(
                name: "IX_Factories_ItemCreatedId",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ItemCreatedId",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Factories");
        }
    }
}
