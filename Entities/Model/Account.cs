using Entities.Compartidas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Account: Auditoria
    {
        [Key]
        [Required]
        public long id { get; set; }
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
        [DataType(DataType.Password)]
        public string pass { get; set; }
        [Required]
        public Guid guid { get; set; }

    }
}
