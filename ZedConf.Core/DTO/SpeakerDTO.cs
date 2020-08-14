using System.ComponentModel.DataAnnotations;
using ZedConf.Entities;

namespace ZedConf.Core.DTO
{
    public class SpeakerDTO 
    {
        public long SpeakerID { get; set; }
        public long TalkID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(150)]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(150)]
        public string Company { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Bio { get; set; }
    }
}
