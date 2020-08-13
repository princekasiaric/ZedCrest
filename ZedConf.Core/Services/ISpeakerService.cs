using System.Collections.Generic;
using System.Threading.Tasks;
using ZedConf.Entities;

namespace ZedConf.Core.Services
{
    public interface ISpeakerService
    {
        Task<ICollection<Speaker>> GetSpeakersAsync();
    }
}
