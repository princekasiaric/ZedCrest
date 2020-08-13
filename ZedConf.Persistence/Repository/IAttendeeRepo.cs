using System.Collections.Generic;
using System.Threading.Tasks;
using ZedConf.Entities;

namespace ZedConf.Persistence.Repository
{
    public interface IAttendeeRepo : IBaseRepo<Attendee>
    {
        Task AddAttendeeAsynce(Attendee attendee);
        Task<ICollection<Attendee>> GetAttendeesAsync();
        Task<ICollection<Attendee>> GetAttendeesByTalkAsync(int talkId);
    }
}
