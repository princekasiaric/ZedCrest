using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using ZedConf.Persistence.Repository;
using ZedConf.Persistence.Repository.Implementation;

namespace ZedConf.Persistence.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbContextTransaction _transaction;

        private readonly ZedConfDbContext _context;

        public UnitOfWork(ZedConfDbContext context)
        {
            _context = context;
        }

        public ITalkRepo TalkRepo => new TalkRepo(_context);

        public ISpeakerRepo SpeakerRepo => new SpeakerRepo(_context);

        public IAttendeeRepo AttendeeRepo => new AttendeeRepo(_context); 

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public async Task CommitChangesAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                    _context.Dispose();
            }
        }
    }
}
