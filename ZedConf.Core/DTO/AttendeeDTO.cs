using System;

namespace ZedConf.Core.DTO
{
    public class AttendeeDTO : BaseDTO
    {
        public long AttendeeID { get; set; }
        public DateTime Registered { get; set; }
        public TalkDTO TalkDTO { get; set; }
    }
}
