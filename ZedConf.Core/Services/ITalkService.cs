using System.Collections.Generic;
using System.Threading.Tasks;
using ZedConf.Core.DTO;
using ZedConf.Core.ViewModel;

namespace ZedConf.Core.Services
{
    public interface ITalkService
    {
        Task AddTalkAsync(TalkDTO talkDTO);
        Task DeleteTalkAsync(long ID);
        Task<TalkDTO> GetTalkByTitleAsync(string title);
        Task<ICollection<TalkDTO>> GetTalksAsync();
        Task AddAttendeeForATalk(TalkViewModel model);
    }
}
