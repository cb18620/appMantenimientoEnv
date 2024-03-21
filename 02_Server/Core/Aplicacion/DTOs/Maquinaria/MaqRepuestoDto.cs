using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs.Maquinaria
{
    public class MaqRepuestoDto
    {
        public int IdmaqRepuesto { get; set; }
        public string Detalle { get; set; }
        public string Codigo { get; set; }
        public string? Valor1 { get; set; }
        public int? Cantidad { get; set; }
        public int? Valor2 { get; set; }
    }
}
