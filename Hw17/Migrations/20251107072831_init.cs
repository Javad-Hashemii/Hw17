using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hw17.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "/Images/Categories/crime.png", "جنایی" },
                    { 2, "/Images/Categories/history.png", "تاریخی" },
                    { 3, "/Images/Categories/fiction.png", "تخیلی" },
                    { 4, "/Images/Categories/science.png", "علمی" },
                    { 5, "/Images/Categories/sci-fi.png", "علمی تخیلی" },
                    { 6, "/Images/Categories/Novel.png", "رمان" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "IsActive", "IsAdmin", "LastName", "Password", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, "یوزر 1", false, false, "", "1234", "09311674121", "user1" },
                    { 2, "یوزر 2", false, false, "", "1234", "09121674121", "user2" },
                    { 3, "مدیر 1", false, true, "", "1234", "09361674121", "admin1" },
                    { 4, "مدیر 2", false, true, "", "1234", "09161674121", "admin2" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "ریچارد آزمن", 1, "/Images/Books/The_Thursday_Murder_Club.jpg", 300000, "باشگاه قتل پنجشنبه" },
                    { 2, "باربارا تاکمن", 2, "/Images/Books/The_Guns_of_August.jpg", 250000, "توپ های ماه اوت" },
                    { 3, "اف اسکات فیتزجرالد", 3, "/Images/Books/The_Great_Gatsby.jpg", 350000, "گتسبی بزرگ" },
                    { 4, "چارلز داروین", 4, "/Images/Books/On_the_Origin_of_Species.jpg", 200000, "منشاء انواع" },
                    { 5, "فرانک هربرت", 5, "/Images/Books/Dune.jpg", 230000, "تلماسه" },
                    { 6, "هارپر لی", 6, "/Images/Books/To_Kill_a_Mockingbird.jpg", 300000, "کشتن مرغ مقلد" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
