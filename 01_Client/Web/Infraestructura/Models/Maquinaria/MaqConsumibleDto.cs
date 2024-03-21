using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Models.Maquinaria
{
    public class MaqConsumibleDto
    {
        public int IdmaqConsumible { get; set; }
        public string Codigo { get; set; }
        public string Detalle { get; set; }
        public string Cantidad { get; set; }
        public bool VerDetalle {  get; set; }
    }
}
