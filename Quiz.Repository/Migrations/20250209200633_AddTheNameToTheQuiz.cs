using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddTheNameToTheQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Quizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Quizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Брза Географија");

            migrationBuilder.UpdateData(
                table: "Quizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Пат низ минатотo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Quizes");
        }
    }
}
