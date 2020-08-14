using System.Collections.Generic;
using System.Threading.Tasks;
using ZedConf.Core.DTO;
using ZedConf.Entities;

namespace ZedConf.Core.Services
{
    public interface ITalkService
    {
        Task AddTalkAsync(TalkDTO talk);
        Task<Talk> GetTalkAsync(int talkID);
        Task DeleteTalkAsync(int ID);
        Task<TalkDTO> GetTalkByTitleAsync(string title);
        Task<ICollection<TalkDTO>> GetTalksAsync();
        Task AddAttendeeForATalk();
    }
}
