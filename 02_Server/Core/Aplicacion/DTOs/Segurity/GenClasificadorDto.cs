using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs.Segurity
{
    public class GenClasificadorDto
    {
        public int IdgenClasificador { get; set; }
        public int idgenClasificadortipo { get; set; }
        public string Descripcion { get; set; }
        public string Valor2 { get; set; }
        public string Valor3 { get; set; }
        public int? Valor4 { get; set; }
        public int? Valor5 { get; set; }
        public string Otro { get; set; }

        public GenClasificadortipoDto Tipo { get; set; } = null!;
    }
}
