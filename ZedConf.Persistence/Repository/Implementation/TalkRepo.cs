using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZedConf.Entities;

namespace ZedConf.Persistence.Repository.Implementation
{
    public class TalkRepo : BaseRepo<Talk>, ITalkRepo
    {
        public ZedConfDbContext ZedConfDbContext => _ctx as ZedConfDbContext;

        public TalkRepo(ZedConfDbContext context) : base(context){}

        public async Task<Talk> GetTalkByTitle(string title) => 
            await ZedConfDbContext.Talks.Where(t => t.Title == title).AsNoTracking().FirstOrDefaultAsync();

        public async Task<ICollection<Talk>> GetTalks() => 
            await ZedConfDbContext.Talks.Include(s => s.Speaker).AsNoTracking().ToListAsync();

        public async Task AddTalkAsync(Talk talk) => await Add(talk);

        public void RemoveTalk(Talk talk) => Remove(talk);

        public async Task<Talk> GetTalkAsync(long talkID) => 
            await ZedConfDbContext.Talks.Where(t => t.TalkID == talkID).FirstOrDefaultAsync();
    }
}
