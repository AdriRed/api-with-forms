using Microsoft.EntityFrameworkCore.Migrations;

namespace APIWithForms.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Alpha = table.Column<byte>(type: "INTEGER", nullable: false),
                    Red = table.Column<byte>(type: "INTEGER", nullable: false),
                    Green = table.Column<byte>(type: "INTEGER", nullable: false),
                    Blue = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserColors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserColors");
        }
    }
}
