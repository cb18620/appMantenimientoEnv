using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs.Maquinaria 
{
    public class MaqMaquinaRepuestoDto
    {
        public int IdmaqMaquinaRepuesto { get; set; }
        public int? IdmaqRepuesto { get; set; }
        public int? Idmaquinaria { get; set; }
        public MaquinariaDto Maquina { get; set; } = null;
        public MaqRepuestoDto Repuesto { get; set; } = null;
    }
}
