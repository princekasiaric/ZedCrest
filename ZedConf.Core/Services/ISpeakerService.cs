using System.Collections.Generic;
using System.Threading.Tasks;
using ZedConf.Core.DTO;

namespace ZedConf.Core.Services
{
    public interface ISpeakerService
    {
        Task<ICollection<SpeakerDTO>> GetSpeakersAsync();
    }
}
