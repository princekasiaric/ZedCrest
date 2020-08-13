using System;

namespace ZedConf.Core.DTO
{
    public abstract class BaseDTO
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
