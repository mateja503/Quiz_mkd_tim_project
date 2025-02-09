using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddTheChangeForTheForengKeyForQuizAndEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizes_Events_EventId",
                table: "Quizes");

            migrationBuilder.DropIndex(
                name: "IX_Quizes_EventId",
                table: "Quizes");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Quizes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Quizes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "QuizId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "QuizId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Events_QuizId",
                table: "Events",
                column: "QuizId",
                unique: true,
                filter: "[QuizId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Quizes_QuizId",
                table: "Events",
                column: "QuizId",
                principalTable: "Quizes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Quizes_QuizId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_QuizId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Quizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Quizes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Quizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "EventId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Quizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "EventId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_EventId",
                table: "Quizes",
                column: "EventId",
                unique: true,
                filter: "[EventId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizes_Events_EventId",
                table: "Quizes",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
