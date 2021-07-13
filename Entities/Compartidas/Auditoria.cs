using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Compartidas
{
    public class Auditoria
    {
        [Required]
        public bool eliminado { get; set; } = false;
        [Required]
        public DateTime fechaAlta { get; set; }
        [Required]
        public string usuarioAlta { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public DateTime fechaRegistracion { get; } = DateTime.Now;
    }
}
