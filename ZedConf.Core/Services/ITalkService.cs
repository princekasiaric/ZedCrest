using System.Collections.Generic;
using System.Threading.Tasks;
using ZedConf.Core.DTO;

namespace ZedConf.Core.Services
{
    public interface ITalkService
    {
        Task<TalkDTO> AddTalkAsync(TalkDTO talk);
        Task<TalkDTO> GetTalkByTitleAsync(string title);
        Task<ICollection<TalkDTO>> GetTalksAsync();
    }
}
