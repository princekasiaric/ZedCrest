using Microsoft.EntityFrameworkCore;
using ZedConf.Entities;

namespace ZedConf.Persistence
{
    public static class ModelConfiguration
    {
        public static void ConfigureTalk(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Talk>(talk =>
            {
                talk.HasKey(t => t.TalkID);
                talk.Property(t => t.Title).IsRequired();
                talk.Property(t => t.Abstract).IsRequired();
                talk.Property(t => t.Room).IsRequired();
                talk.Property(t => t.RowVersion).IsRowVersion().IsRequired();
                talk.HasOne(t => t.Speaker).WithOne(s => s.Talk).OnDelete(DeleteBehavior.Cascade);
                talk.HasMany(t => t.Attendees).WithOne(a => a.Talk).HasForeignKey(s => s.TalkID).OnDelete(DeleteBehavior.Cascade);
                talk.Property(t => t.CreatedAt).HasDefaultValueSql("GetDate()").ValueGeneratedOnAddOrUpdate();
            });
        }

        public static void ConfigureSpeaker(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speaker>(speaker =>
            {
                speaker.HasKey(s => s.SpeakerID);
                speaker.Property(s => s.Name).IsRequired();
                speaker.Property(s => s.Company).IsRequired();
                speaker.Property(s => s.Email).IsRequired();
                speaker.Property(s => s.Bio).IsRequired();
                speaker.Property(s => s.RowVersion).IsRowVersion().IsRequired();
                speaker.HasOne(s => s.Talk).WithOne(t => t.Speaker).OnDelete(DeleteBehavior.Cascade);
                speaker.Property(s => s.CreatedAt).HasDefaultValueSql("GetDate()").ValueGeneratedOnAddOrUpdate();
            });
        }

        public static void ConfigureAttendee(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>(attendee =>
            {
                attendee.HasKey(s => s.AttendeeID);
                attendee.Property(s => s.Name).IsRequired();
                attendee.Property(s => s.Company).IsRequired();
                attendee.Property(s => s.Email).IsRequired();
                attendee.Property(s => s.RowVersion).IsRowVersion().IsRequired();
                attendee.HasOne(a => a.Talk).WithMany(t => t.Attendees).HasForeignKey(a => a.TalkID).OnDelete(DeleteBehavior.Cascade);
                attendee.Property(s => s.CreatedAt).HasDefaultValueSql("GetDate()").ValueGeneratedOnAddOrUpdate();
            });
        }
    }
}
