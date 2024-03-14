using Dominio.Entities.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Models.Maquinaria
{
    public class MaqCaractInfraDto
    {
        public int IdmaqCaractInfra { get; set; }
        public int Idmaquinaria { get; set; }
        public string Puertas { get; set; }
        public string Ventanas { get; set; }
        public string Luminarias { get; set; }
        public string Tomas { get; set; }
        public string Largo { get; set; }
        public string Ancho { get; set; }
        public string Altura { get; set; }
        public bool VerDetalle { get; set; }
    }
}
