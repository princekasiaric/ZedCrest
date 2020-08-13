using System.Collections.Generic;
using System.Threading.Tasks;
using ZedConf.Entities;

namespace ZedConf.Persistence.Repository
{
    public interface ISpeakerRepo : IBaseRepo<Speaker>
    {
        Task<ICollection<Speaker>> GetSpeakers();
    }
}
