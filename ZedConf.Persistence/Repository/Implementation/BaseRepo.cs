using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ZedConf.Persistence.Repository.Implementation
{
    public abstract class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        protected readonly DbContext _ctx;

        public BaseRepo(DbContext context) => _ctx = context;

        public async Task Add(T entity) => await _ctx.Set<T>().AddAsync(entity);

        public void Remove(T entity) => _ctx.Set<T>().Remove(entity);

        ~BaseRepo()
        {

        }
    }
}
