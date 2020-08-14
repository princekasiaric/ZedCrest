using System.Collections.Generic;
using ZedConf.Entities;

namespace ZedConf.Core.ViewModel
{
    public class TalkViewModel
    {
        public int TalkID { get; set; }
        public ICollection<Attendee> Attendees { get; set; }
    }
}
