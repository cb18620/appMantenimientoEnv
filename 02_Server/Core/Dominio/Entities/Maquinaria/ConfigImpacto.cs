using Dominio.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Entities
{
    [Table("config_impacto", Schema = "public")]
    public class ConfigImpacto : AuditableBaseEntity
    {
        [Key]
        public int IdconfigImpacto { get; set; }
        public decimal? Valor { get; set; }  
        public string Nombre { get; set; }
    }
}
