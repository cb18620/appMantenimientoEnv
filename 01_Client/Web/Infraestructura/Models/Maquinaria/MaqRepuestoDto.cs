using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Models.Maquinaria
{
    public class MaqRepuestoDto
    {
        public int IdmaqRepuesto { get; set; }
        public string Detalle { get; set; }
        public string Codigo { get; set; }
        public int? Valor1 { get; set; }
        public int Cantidad { get; set; }
        public int? Valor2 { get; set; }
        public bool VerDetalle { get; set; }    
    }

}
