using Dominio.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Entities
{
    [Table("maq_maquina_repuesto", Schema = "public")]
    public class MaqMaquinaRepuesto : AuditableBaseEntity 
    {
        [Key]
        public int IdmaqMaquinaRepuesto { get; set; }
        public int? IdmaqRepuesto { get; set; }
        public int? Idmaquinaria { get; set; }

        [ForeignKey("Idmaquinaria")]
        public Maquinaria Maquina { get; set; } = null;
        [ForeignKey("IdmaqRepuesto")]
        public MaqRepuesto Repuesto { get; set; } = null;

    }
}
