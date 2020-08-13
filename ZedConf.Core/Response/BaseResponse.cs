using System;

namespace ZedConf.Core.Response
{
    public abstract class BaseResponse
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
