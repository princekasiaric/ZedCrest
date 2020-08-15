using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZedConf.Entities;

namespace ZedConf.Persistence.Repository.Implementation
{
    public class AttendeeRepo : BaseRepo<Attendee>, IAttendeeRepo
    {
        public ZedConfDbContext ZedConfDbContext => _ctx as ZedConfDbContext;

        public AttendeeRepo(ZedConfDbContext context) : base(context){}

        public async Task<ICollection<Attendee>> GetAttendeesAsync() =>
            await ZedConfDbContext.Attendees.AsNoTracking().ToListAsync();

        public async Task<ICollection<Attendee>> GetAttendeesByTalkAsync(long talkId) => 
            await ZedConfDbContext.Attendees.Where(t => t.Talk.TalkID == talkId).AsNoTracking().ToListAsync();

        public async Task AddAttendeeAsynce(Attendee attendee) => await Add(attendee);

        public async Task<Attendee> GetAttendeeAsync(long attendeeID) => 
            await ZedConfDbContext.Attendees.Where(t => t.AttendeeID == attendeeID).FirstOrDefaultAsync();
    }
}
