using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class AccountDTO
    {
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        public string usuario { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string mail { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "La contraseña de bebe tener minimo 5 carateres y maximo 12", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string pass { get; set; }
    }
}
