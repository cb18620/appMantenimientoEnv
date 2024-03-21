using Dominio.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Entities
{
    [Table("maq_repuesto", Schema = "public")]
    public class MaqRepuesto : AuditableBaseEntity
    {
       
        [Key]
        public int IdmaqRepuesto { get; set; }
        public string Detalle { get; set; }
        public string Codigo { get; set; }
        public string? Valor1 { get; set; }
        public int? Cantidad { get; set; }
        public int? Valor2 { get; set; }
    }
}
