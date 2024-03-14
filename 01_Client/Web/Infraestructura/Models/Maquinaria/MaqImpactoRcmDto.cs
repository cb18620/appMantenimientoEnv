using Infraestructura.Models.Clasificador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Models.Maquinaria
{
    public class MaqImpactoRcmDto
    {
        public int IdmaqImpactoRcm { get; set; }
        public int Idmaquinaria { get; set; }
        public MaquinariaDto Maquinaria { get; set; }
        public int IdgenClasificador { get; set; }
        public GenClasificadorDto Clasificador { get; set; }
        public int IdconfigImpacto { get; set; }
        public ConfigImpactoDto Impacto { get; set; }
        public bool VerDetalle { get; set; }
    }
}
