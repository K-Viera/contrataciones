using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contrataciones.Models
{
    public class Trabajador
    {
        public int ID { get; set; }
        public string TipoIdentificacion { get; set; }
        public int NumIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string edad { get; set; }

        public ICollection<Contrato> Contratos { get; set; }
    }
}
