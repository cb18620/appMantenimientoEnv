using Dominio.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Entities
{
    [Table("maq_maquina_consumible", Schema = "public")]
    public class MaqMaquinaConsumible : AuditableBaseEntity
    {
        [Key]
        public int IdmaqMaquinaConsumible { get; set; }
        public int? IdmaqConsumible { get; set; }
        public int? Idmaquinaria { get; set; }

        [ForeignKey("Idmaquinaria")]
        public Maquinaria Maquina { get; set; } = null;
        [ForeignKey("IdmaqConsumible")]
        public MaqConsumible Consumible { get; set; } = null!; 

    }
}
