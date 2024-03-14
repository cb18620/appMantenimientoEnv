using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Models.Clasificador
{
    public partial class GenClasificadorDto
    {
        public int IdgenClasificador { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un tipo de clasificador.")]
        public int IdgenClasificadortipo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Descripcion { get; set; }
        public string Valor2 { get; set; }
        public string Valor3 { get; set; }
        public int? Valor4 { get; set; }
        public int? Valor5 { get; set; }
        public string Otro { get; set; }
        public GenClasificadortipoDto Tipo { get; set; } = null!;
        public bool VerDetalle { get; set; }
    }
}
