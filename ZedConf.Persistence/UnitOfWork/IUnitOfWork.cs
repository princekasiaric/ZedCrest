using System;
using System.Threading.Tasks;
using ZedConf.Persistence.Repository;

namespace ZedConf.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ITalkRepo TalkRepo { get; }
        ISpeakerRepo SpeakerRepo { get; }
        IAttendeeRepo AttendeeRepo { get; }

        Task<int> SaveAsync();
        Task CommitChangesAsync();
    }
}
