using ZedConf.Core.Request;
using ZedConf.Core.Response;

namespace ZedConf.Core.Services
{
    public interface IBaseService<T, U> where T : BaseDTO where U : BaseResponse
    {
    }
}
