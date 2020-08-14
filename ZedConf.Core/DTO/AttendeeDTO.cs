using System;
using System.ComponentModel.DataAnnotations;

namespace ZedConf.Core.DTO
{
    public class AttendeeDTO 
    {
        public long AttendeeID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        public string Company { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "This fied is required")]
        [DataType(DataType.Date)]
        public DateTime Registered { get; set; }

        public long TalkID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(150)]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Abstract { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int Room { get; set; }
    }
}
