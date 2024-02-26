using Dominio.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Entities
{
    [Table("maq_maquina_elemento", Schema = "public")]
    public class MaqMaquinaElemento : AuditableBaseEntity
    {
        [Key]
        public int IdmaquinaElemento { get; set; }
        public int? Idmaquinaria { get; set; }
        public int? Idelemento { get; set; }

        [ForeignKey("Idmaquinaria")]
        public  Maquinaria Machinery { get; set; } = null;
        [ForeignKey("Idelemento")]
        public  MaqElemento MaqElement { get; set; } = null!;
    }
}
