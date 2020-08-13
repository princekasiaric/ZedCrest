using Microsoft.EntityFrameworkCore;
using ZedConf.Entities;

namespace ZedConf.Persistence
{
    public class ZedConfDbContext : DbContext
    {
        public ZedConfDbContext(DbContextOptions<ZedConfDbContext> dbContextOptions) : base(dbContextOptions){}

        public DbSet<Talk> Talks { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureTalk();
            modelBuilder.ConfigureSpeaker();
            modelBuilder.ConfigureAttendee();

            modelBuilder.SeededTalk();
            modelBuilder.SeededSpeaker();
            modelBuilder.SeededAttendee();
        }
    }
}
