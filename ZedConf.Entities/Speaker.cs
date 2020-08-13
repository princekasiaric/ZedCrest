using System;

namespace ZedConf.Entities
{
    public class Speaker
    {
        public long SpeakerID { get; set; }
        public long TalkID { get; set; }
        public Talk Talk { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
