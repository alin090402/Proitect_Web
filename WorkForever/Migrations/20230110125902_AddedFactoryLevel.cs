using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkForever.Migrations
{
    /// <inheritdoc />
    public partial class AddedFactoryLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FactoryLevel",
                table: "Factories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FactoryLevel",
                table: "Factories");
        }
    }
}
