using System.Collections.Generic;
using System.Threading.Tasks;
using ZedConf.Entities;

namespace ZedConf.Persistence.Repository
{
    public interface ITalkRepo : IBaseRepo<Talk>
    {
        Task AddTalkAsync(Talk talk);
        Task<Talk> GetTalkByTitle(string title);
        Task<ICollection<Talk>> GetTalks();
    }
}
