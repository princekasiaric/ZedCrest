using System;
using System.Collections.Generic;
using System.Text;

namespace ZedConf.Core.Response
{
    public class SpeakerResponse : BaseResponse
    {
        public long SpeakerID { get; set; }
        public string Bio { get; set; }
    }
}
