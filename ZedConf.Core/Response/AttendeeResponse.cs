using System;
using System.Collections.Generic;
using System.Text;

namespace ZedConf.Core.Response
{
    public class AttendeeResponse : BaseResponse
    {
        public long AttendeeID { get; set; }
        public long TalkID { get; set; }

        public DateTime Registered { get; set; }
    }
}
