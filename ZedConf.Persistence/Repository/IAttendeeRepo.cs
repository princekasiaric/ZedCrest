using System.Collections.Generic;
using System.Threading.Tasks;
using ZedConf.Entities;

namespace ZedConf.Persistence.Repository
{
    public interface IAttendeeRepo : IBaseRepo<Attendee>
    {
        Task<Attendee> GetAttendeeAsync(long attendeeID);
        Task AddAttendeeAsynce(Attendee attendee);
        Task<ICollection<Attendee>> GetAttendeesAsync();
        Task<ICollection<Attendee>> GetAttendeesByTalkAsync(long talkId);
    }
}
