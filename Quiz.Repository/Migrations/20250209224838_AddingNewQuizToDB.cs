using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Quiz.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewQuizToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Quizes_TypeQuizeId",
                table: "Quizes");

            migrationBuilder.InsertData(
                table: "Quizes",
                columns: new[] { "Id", "Name", "TypeQuizeId" },
                values: new object[] { 3, "Брза географија 2 дел", 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "QuizId", "Text" },
                values: new object[,]
                {
                    { 11, 3, "Кој е најголемиот остров во Охридското Езеро?" },
                    { 12, 3, "Која карпеста формација во Македонија е позната како „Камени кукли“ ?" },
                    { 13, 3, "Кој град во Македонија се наоѓа најсеверно?" },
                    { 14, 3, "Која е најдлабоката пештера во Македонија?" },
                    { 15, 3, "На која река се наоѓа Козјак – најголемото вештачко езеро во Македонија?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "QuestionId", "Text", "isCorrect" },
                values: new object[,]
                {
                    { 41, 11, "Градско Острово", false },
                    { 42, 11, "Голем Град", true },
                    { 43, 11, "Мал Град", false },
                    { 44, 11, "Пештани", false },
                    { 45, 12, "Куклица", true },
                    { 46, 12, "Маркови Кули", false },
                    { 47, 12, "Долни Полог", false },
                    { 48, 12, "Плочата", false },
                    { 49, 13, "Куманово", true },
                    { 50, 13, "Крива Паланка", false },
                    { 51, 13, "Тетово", false },
                    { 52, 13, "Кратово", false },
                    { 53, 14, "Слатински Извор", false },
                    { 54, 14, "Врело", true },
                    { 55, 14, "Алилица", false },
                    { 56, 14, "Голубарница", false },
                    { 57, 15, "Треска", true },
                    { 58, 15, "Вардар", false },
                    { 59, 15, "Радика", false },
                    { 60, 15, "Црна", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_TypeQuizeId",
                table: "Quizes",
                column: "TypeQuizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Quizes_TypeQuizeId",
                table: "Quizes");

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Quizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_TypeQuizeId",
                table: "Quizes",
                column: "TypeQuizeId",
                unique: true);
        }
    }
}
