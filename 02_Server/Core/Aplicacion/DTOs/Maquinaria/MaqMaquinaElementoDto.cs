using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs.Maquinaria
{
    public class MaqMaquinaElementoDto 
                 
    {
        public int IdmaquinaElemento { get; set; }
        public int? Idmaquinaria { get; set; }
        public int Idelemento { get; set; }
        public MaquinariaDto Machinery { get; set; } = null;
        public MaqElementoDto MaqElement { get; set; } = null!;
    }
}

