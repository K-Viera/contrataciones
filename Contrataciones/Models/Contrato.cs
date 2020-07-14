using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contrataciones.Models
{
    public class Contrato
    {
        public int ContratoID { get; set; }
        public string NombreEntidad { get; set; }
        public int NumeroContrato { get; set; }

        public int TrabajadorID { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        public Trabajador Trabajador { get; set; }
    }
}
