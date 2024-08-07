using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "DueDate", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("5ce5c3ea-b45c-47dd-8765-aa2b50166e65"), "Description 3", new DateOnly(1, 1, 1), false, "Task 3" },
                    { new Guid("6afa3e32-2ba9-4a5c-9889-bd06f59607e9"), "Description 1", new DateOnly(1, 1, 1), true, "Task 1" },
                    { new Guid("e3e77baf-8d0e-4472-9148-41e6c0332419"), "Description 2", new DateOnly(1, 1, 1), true, "Task 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
