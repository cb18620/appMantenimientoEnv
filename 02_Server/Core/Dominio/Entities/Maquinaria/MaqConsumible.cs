using Dominio.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Entities
{
    [Table("maq_consumible", Schema = "public")]
    public class MaqConsumible : AuditableBaseEntity
    {
        [Key]
        public int IdmaqConsumible { get; set; }
        public string Codigo { get; set; }
        public string Detalle { get; set; }
        public string Cantidad { get; set; }
    }
}
