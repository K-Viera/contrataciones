using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contrataciones.Data;
using Contrataciones.Models;

namespace Contrataciones.Data
{
    public class DbInitializer
    {
        public static void Initialize(ContratacionesContext context)
        {
            //context.Database.EnsureCreated();

            if (context.Trabajadores.Any())
            {
                return;
            }

            var trabajadores = new Trabajador[]
            {
                new Trabajador{TipoIdentificacion="Cedula",NumIdentificacion=123,PrimerNombre="Kevin",SegundoNombre="Cleider",PrimerApellido="Viera",SegundoApellido="Jaramillo",FechaNacimiento=DateTime.Parse("2001-08-26"),edad="18"},
                new Trabajador{TipoIdentificacion="Cedula",NumIdentificacion=1234,PrimerNombre="Monica",SegundoNombre="Sara",PrimerApellido="Escobar",SegundoApellido="Tamayo",FechaNacimiento=DateTime.Parse("2001-08-26"),edad="18"}
            };

            context.Trabajadores.AddRange(trabajadores);
            context.SaveChanges();

            var contratos = new Contrato[]
            {
                new Contrato{NombreEntidad="Servientrega",NumeroContrato=12345,TrabajadorID=1,FechaInicio=DateTime.Parse("2001-08-26")},
                new Contrato{NombreEntidad="Servientrega",NumeroContrato=123435,TrabajadorID=2,FechaInicio=DateTime.Parse("2001-08-26")},
                new Contrato{NombreEntidad="Banco de Bogota",NumeroContrato=122345,TrabajadorID=1,FechaInicio=DateTime.Parse("2001-08-26")}

            };

            context.Contratos.AddRange(contratos);
            context.SaveChanges();

        }
    }
}
