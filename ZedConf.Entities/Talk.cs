using System;
using System.Collections.Generic;

namespace ZedConf.Entities
{
    public class Talk
    {
        public long TalkID { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public int Room { get; set; }
        public Speaker Speaker { get; set; }
        public ICollection<Attendee> Attendees { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
