namespace School.Database.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitiallMigration : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Cabinetes");

            migrationBuilder.DropTable(
                "Classes");

            migrationBuilder.DropTable(
                "SubjectsPget");

            migrationBuilder.DropTable(
                "Teachers");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Cabinetes",
                table => new
                {
                    Id = table.Column<string>("text"),
                    Name = table.Column<string>("text", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Cabinetes", x => x.Id); });

            migrationBuilder.CreateTable(
                "Classes",
                table => new
                {
                    Id = table.Column<string>("text"),
                    Litera = table.Column<char>("character(1)"),
                    Grade = table.Column<int>("integer")
                },
                constraints: table => { table.PrimaryKey("PK_Classes", x => x.Id); });

            migrationBuilder.CreateTable(
                "SubjectsPget",
                table => new
                {
                    Id = table.Column<string>("text"),
                    Name = table.Column<string>("text", nullable: true),
                    MaxPerWeek = table.Column<int>("integer")
                },
                constraints: table => { table.PrimaryKey("PK_SubjectsPget", x => x.Id); });

            migrationBuilder.CreateTable(
                "Teachers",
                table => new
                {
                    Id = table.Column<string>("text"),
                    Name = table.Column<string>("text", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Teachers", x => x.Id); });
        }
    }
}