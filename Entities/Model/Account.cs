using Entities.Compartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Account: Auditoria
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string usuario { get; set; }
        public string mail { get; set; }
        public string pass { get; set; }
    }
}
