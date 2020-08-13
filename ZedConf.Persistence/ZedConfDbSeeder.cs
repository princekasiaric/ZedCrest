using Microsoft.EntityFrameworkCore;
using System;
using ZedConf.Entities;

namespace ZedConf.Persistence
{
    public static class ZedConfDbSeeder
    {
        public static void SeededTalk(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Talk>(talk =>
            {
                talk.HasData(
                    new Talk {
                        TalkID = 1,
                        Title = "CILLUM NON",
                        Abstract = "Aliqua consequat mollit Lorem dolor nulla qui sunt tempor veniam eiusmod ullamco quis commodo.",
                        Room = 873,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Talk { 
                        TalkID = 2,
                        Title = "AD IPSUM",
                        Abstract = "Fugiat nisi et mollit consequat sint.",
                        Room = 343,
                        CreatedAt = DateTime.UtcNow
                    });
            });
        }

        public static void SeededSpeaker(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speaker>(speaker =>
            {
                speaker.HasData(
                    new Speaker {
                        SpeakerID = 1,
                        TalkID = 1,
                        Name = "Hendrix Carroll",
                        Company = "Songlines",
                        Email = "hendrixcarroll@songlines.com",
                        Bio = "Magna velit adipisicing ullamco sint duis nisi.",
                        CreatedAt = DateTime.UtcNow
                    },
                    new Speaker {
                        SpeakerID = 2,
                        TalkID = 2,
                        Name = "Melody Juarez",
                        Company = "Zillatide",
                        Email = "melodyjuarez@zillatide.com",
                        Bio = "Veniam do eu quis officia enim.",
                        CreatedAt = DateTime.UtcNow
                    });
            });
        }

        public static void SeededAttendee(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>(attendee =>
            {
                attendee.HasData(
                    new Attendee {
                        AttendeeID = 1,
                        TalkID = 1,
                        Name = "Sanders Riley",
                        Company = "Comtext",
                        Email = "sandersriley@comtext.com",
                        Registered = DateTime.UtcNow,
                        CreatedAt = DateTime.UtcNow,
                    },
                    new Attendee {
                        AttendeeID = 2,
                        TalkID = 1,
                        Name = "Bean Cline",
                        Company = "Utarian",
                        Email = "beancline@utarian.com",
                        Registered = DateTime.UtcNow,
                        CreatedAt = DateTime.UtcNow,
                    },
                    new Attendee {
                        AttendeeID = 3,
                        TalkID = 1,
                        Name = "Alfreda Mitchell",
                        Company = "Dreamia",
                        Email = "alfredamitchell@dreamia.com",
                        Registered = DateTime.UtcNow,
                        CreatedAt = DateTime.UtcNow,
                    });
            });
        }
    }
}
