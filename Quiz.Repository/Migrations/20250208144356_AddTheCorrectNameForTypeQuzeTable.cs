using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddTheCorrectNameForTypeQuzeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizes_TypeQuizzes_TypeQuizeId",
                table: "Quizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeQuizzes",
                table: "TypeQuizzes");

            migrationBuilder.RenameTable(
                name: "TypeQuizzes",
                newName: "TypeQuizes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeQuizes",
                table: "TypeQuizes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizes_TypeQuizes_TypeQuizeId",
                table: "Quizes",
                column: "TypeQuizeId",
                principalTable: "TypeQuizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizes_TypeQuizes_TypeQuizeId",
                table: "Quizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeQuizes",
                table: "TypeQuizes");

            migrationBuilder.RenameTable(
                name: "TypeQuizes",
                newName: "TypeQuizzes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeQuizzes",
                table: "TypeQuizzes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizes_TypeQuizzes_TypeQuizeId",
                table: "Quizes",
                column: "TypeQuizeId",
                principalTable: "TypeQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
