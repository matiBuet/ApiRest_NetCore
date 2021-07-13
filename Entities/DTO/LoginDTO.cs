using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTO
{
    public class LoginDTO
    {
        [Required]
        public string usuario { get; set; } = "demo";
        [Required]
        [DataType(DataType.Password)]
        public string pass { get; set; } = "123456";
    }
}
