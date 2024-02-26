
using Infraestructura.Models.Clasificador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Models.Parametricas
{
    public class PersonaDto
    {
        public int Idpersonal { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Especialidad { get; set; }
        public GenClasificadorDto Especialidades { get; set; }
        public int? Telefono { get; set; }
        public string Ci { get; set; }
        public string Correo { get; set; }
        public string Foto { get; set; }

        public bool VerDetalle { get; set; }
    }
}
