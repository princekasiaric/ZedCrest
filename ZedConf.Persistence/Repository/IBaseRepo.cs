using System.Threading.Tasks;

namespace ZedConf.Persistence.Repository
{
    public interface IBaseRepo<T> where T : class
    {
        Task Add(T entity);
        void Remove(T entity);
    }
}
