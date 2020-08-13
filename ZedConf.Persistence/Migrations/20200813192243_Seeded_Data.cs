using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZedConf.Persistence.Migrations
{
    public partial class Seeded_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Talks",
                columns: new[] { "TalkID", "Abstract", "Room", "Title" },
                values: new object[] { 1L, "Aliqua consequat mollit Lorem dolor nulla qui sunt tempor veniam eiusmod ullamco quis commodo.", 873, "CILLUM NON" });

            migrationBuilder.InsertData(
                table: "Talks",
                columns: new[] { "TalkID", "Abstract", "Room", "Title" },
                values: new object[] { 2L, "Fugiat nisi et mollit consequat sint.", 343, "AD IPSUM" });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "AttendeeID", "Company", "Email", "Name", "Registered", "TalkID" },
                values: new object[,]
                {
                    { 1L, "Comtext", "sandersriley@comtext.com", "Sanders Riley", new DateTime(2020, 8, 13, 19, 22, 42, 243, DateTimeKind.Utc).AddTicks(6294), 1L },
                    { 2L, "Utarian", "beancline@utarian.com", "Bean Cline", new DateTime(2020, 8, 13, 19, 22, 42, 243, DateTimeKind.Utc).AddTicks(8456), 1L },
                    { 3L, "Dreamia", "alfredamitchell@dreamia.com", "Alfreda Mitchell", new DateTime(2020, 8, 13, 19, 22, 42, 243, DateTimeKind.Utc).AddTicks(8493), 1L }
                });

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "SpeakerID", "Bio", "Company", "Email", "Name", "TalkID" },
                values: new object[,]
                {
                    { 1L, "Magna velit adipisicing ullamco sint duis nisi.", "Songlines", "hendrixcarroll@songlines.com", "Hendrix Carroll", 1L },
                    { 2L, "Veniam do eu quis officia enim.", "Zillatide", "melodyjuarez@zillatide.com", "Melody Juarez", 2L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "AttendeeID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "AttendeeID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "AttendeeID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "SpeakerID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "SpeakerID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Talks",
                keyColumn: "TalkID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Talks",
                keyColumn: "TalkID",
                keyValue: 2L);
        }
    }
}
