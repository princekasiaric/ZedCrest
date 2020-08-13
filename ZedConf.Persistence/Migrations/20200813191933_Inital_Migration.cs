using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZedConf.Persistence.Migrations
{
    public partial class Inital_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Talks",
                columns: table => new
                {
                    TalkID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Abstract = table.Column<string>(nullable: false),
                    Room = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talks", x => x.TalkID);
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    AttendeeID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TalkID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Company = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Registered = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.AttendeeID);
                    table.ForeignKey(
                        name: "FK_Attendees_Talks_TalkID",
                        column: x => x.TalkID,
                        principalTable: "Talks",
                        principalColumn: "TalkID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    SpeakerID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TalkID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Company = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Bio = table.Column<string>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.SpeakerID);
                    table.ForeignKey(
                        name: "FK_Speakers_Talks_TalkID",
                        column: x => x.TalkID,
                        principalTable: "Talks",
                        principalColumn: "TalkID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_TalkID",
                table: "Attendees",
                column: "TalkID");

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_TalkID",
                table: "Speakers",
                column: "TalkID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropTable(
                name: "Talks");
        }
    }
}
