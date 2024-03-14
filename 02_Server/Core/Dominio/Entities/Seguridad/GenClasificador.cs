using Dominio.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entities.Seguridad
{

    [Table("gen_clasificador", Schema ="public")]
    public class GenClasificador : AuditableBaseEntity 
    {
        [Key]
        public int IdgenClasificador { get; set; }
        public int IdgenClasificadortipo { get; set; }
        public string Descripcion { get; set; }
        public string Valor2 { get; set; }
        public string Valor3 { get; set; }
        public int? Valor4 { get; set; }
        public int? Valor5 { get; set; }
        public string Otro { get; set; }
        [ForeignKey("IdgenClasificadortipo")]
        public GenClasificadortipo Tipo { get; set; } = null!;

    }
}
