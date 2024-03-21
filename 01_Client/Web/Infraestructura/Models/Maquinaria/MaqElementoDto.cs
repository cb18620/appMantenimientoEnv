using Infraestructura.Models.Maquinaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Models.Maquinaria
{
    public class MaqElementoDto 
    {
        public int Idelemento { get; set; }
        public string Descripcion { get; set; }
        public string Funcion { get; set; }
        public bool VerDetalle { get; set; }  
    }
}
