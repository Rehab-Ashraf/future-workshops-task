using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FutureWorkshops.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "Id", "DeletionDate", "DueDate", "IsDeleted", "Name", "Status" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), false, "Design homepage UI", 1 },
                    { 2, null, new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), false, "Implement login feature", 2 },
                    { 3, null, new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Local), false, "Write unit tests for backend services", 1 },
                    { 4, null, new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Local), false, "Deploy initial version to staging", 1 },
                    { 5, null, new DateTime(2025, 8, 7, 0, 0, 0, 0, DateTimeKind.Local), false, "Fix bugs from QA feedback", 2 },
                    { 6, null, new DateTime(2025, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), false, "Review code and optimize queries", 3 },
                    { 7, null, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), false, "Document API endpoints", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
