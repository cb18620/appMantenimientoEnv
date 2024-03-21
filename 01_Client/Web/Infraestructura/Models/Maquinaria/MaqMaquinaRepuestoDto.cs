using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Models.Maquinaria
{
    public class MaqMaquinaRepuestoDto
    {
        public int IdmaqMaquinaRepuesto { get; set; }
        public int? IdmaqRepuesto { get; set; }
        public int? Idmaquinaria { get; set; }
        public MaquinariaDto Maquina { get; set; }
        public MaqRepuestoDto Repuesto { get; set; } 
        public bool VerDetalle { get; set; }
    }
}
