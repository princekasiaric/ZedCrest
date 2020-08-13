using System;

namespace ZedConf.Core.DTO
{
    public class TalkDTO
    {
        public long TalkID { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public int Room { get; set; }
        public SpeakerDTO SpeakerDTO { get; set; }
        public AttendeeDTO AttendeeDTO { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
