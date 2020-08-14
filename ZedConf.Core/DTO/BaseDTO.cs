using System;
using System.ComponentModel.DataAnnotations;

namespace ZedConf.Core.DTO
{
    public abstract class BaseDTO
    {
        [Required(ErrorMessage ="This field is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [StringLength(50)]
        public string Company { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
