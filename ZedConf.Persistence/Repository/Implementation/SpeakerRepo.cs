using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZedConf.Entities;

namespace ZedConf.Persistence.Repository.Implementation
{
    public class SpeakerRepo : BaseRepo<Speaker>, ISpeakerRepo
    {
        public ZedConfDbContext ZedConfDbContext => _ctx as ZedConfDbContext;

        public SpeakerRepo(ZedConfDbContext context) : base(context){}

        public async Task<ICollection<Speaker>> GetSpeakers() => 
            await ZedConfDbContext.Speakers.AsNoTracking().ToListAsync();
    }
}
