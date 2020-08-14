using System;
using System.ComponentModel.DataAnnotations;

namespace ZedConf.Core.DTO
{
    public class AttendeeDTO : BaseDTO
    {
        public long AttendeeID { get; set; }

        [Required(ErrorMessage = "This fied is required")]
        [DataType(DataType.Date)]
        public DateTime Registered { get; set; }

        public TalkDTO TalkDTO { get; set; }
    }
}
