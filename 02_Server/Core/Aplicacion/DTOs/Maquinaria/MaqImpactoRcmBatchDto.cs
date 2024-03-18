using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs.Maquinaria
{
       public class MaqImpactoRcmBatchDto
    {
        public int? IdMaquinaria { get; set; }
        public List<ImpactoItemDto> Impactos { get; set; }
    }

    public class ImpactoItemDto
    {
        public int IdgenClasificador { get; set; }
        public int IdconfigImpacto { get; set; }
    }
}
