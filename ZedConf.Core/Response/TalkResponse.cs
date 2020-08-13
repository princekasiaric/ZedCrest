using System;
using System.Collections.Generic;
using System.Text;

namespace ZedConf.Core.Response
{
    public class TalkResponse : BaseResponse
    {
        public long TalkID { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public int Room { get; set; }


        public DateTime Registered { get; set; }
    }
}
