using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTO
{
    public class AccountDataDTO
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string usuario { get; set; }
        public string mail { get; set; }
    }
}
