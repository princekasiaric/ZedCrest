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
            await ZedConfDbContext.Talks.Include(s => s.Speaker).Include(a => a.Attendees).AsNoTracking().ToListAsync();

        public async Task AddTalkAsync(Talk talk) => await Add(talk);
    }
}
