namespace School.Scheduler.Database.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Initial : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Lessons");

            migrationBuilder.DropTable(
                "SchedulerNote");

            migrationBuilder.DropTable(
                "Cells");

            migrationBuilder.DropTable(
                "UserNotes");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Cells",
                table => new
                {
                    Id = table.Column<string>("text"),
                    Start = table.Column<DateTime>("timestamp without time zone"),
                    End = table.Column<DateTime>("timestamp without time zone"),
                    Order = table.Column<int>("integer")
                },
                constraints: table => { table.PrimaryKey("PK_Cells", x => x.Id); });

            migrationBuilder.CreateTable(
                "UserNotes",
                table => new
                {
                    Id = table.Column<string>("text"),
                    StartUserId = table.Column<string>("text", nullable: true),
                    StartDate = table.Column<DateTime>("timestamp without time zone"),
                    EndDate = table.Column<DateTime>("timestamp without time zone", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_UserNotes", x => x.Id); });

            migrationBuilder.CreateTable(
                "Lessons",
                table => new
                {
                    Id = table.Column<string>("text"),
                    TeacherId = table.Column<string>("text", nullable: true),
                    SubjectId = table.Column<string>("text", nullable: true),
                    ClassId = table.Column<string>("text", nullable: true),
                    TimeId = table.Column<string>("text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        "FK_Lessons_Cells_TimeId",
                        x => x.TimeId,
                        "Cells",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "SchedulerNote",
                table => new
                {
                    Id = table.Column<string>("text"),
                    Description = table.Column<string>("text", nullable: true),
                    UserNoteId = table.Column<string>("text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulerNote", x => x.Id);
                    table.ForeignKey(
                        "FK_SchedulerNote_UserNotes_UserNoteId",
                        x => x.UserNoteId,
                        "UserNotes",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Lessons_TimeId",
                "Lessons",
                "TimeId");

            migrationBuilder.CreateIndex(
                "IX_SchedulerNote_UserNoteId",
                "SchedulerNote",
                "UserNoteId");
        }
    }
}