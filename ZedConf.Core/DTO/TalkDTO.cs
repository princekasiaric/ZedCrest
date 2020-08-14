using System;
using System.ComponentModel.DataAnnotations;

namespace ZedConf.Core.DTO
{
    public class TalkDTO
    {
        public long TalkID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(150)]
        public string Title { get; set; }

        [Required(ErrorMessage ="This field is required")]
        public string Abstract { get; set; }

        [Required(ErrorMessage ="This field is required")]
        public int Room { get; set; }

        public SpeakerDTO SpeakerDTO { get; set; }
        public AttendeeDTO AttendeeDTO { get; set; }
    }
}
