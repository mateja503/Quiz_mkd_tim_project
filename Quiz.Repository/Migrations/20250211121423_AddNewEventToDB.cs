using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddNewEventToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Name", "QuizId", "StartDate" },
                values: new object[] { 3, "Провери си го знаење за Географија 2 дел во Северна Македонија", new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Географија на Северна Македонија 2 дел", null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
