using Dominio.Common;
using Dominio.Entities.Seguridad;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Entities
{
    [Table("maq_impacto_rcm", Schema = "public")]
    public class MaqImpactoRcm : AuditableBaseEntity
    {
        [Key]
        public int IdmaqImpactoRcm { get; set; }
        public int? Idmaquinaria { get; set; }
        public int? IdgenClasificador { get; set; }
        public int? IdconfigImpacto { get; set; }
        [ForeignKey("Idmaquinaria")]
        public virtual Maquinaria Maquinaria { get; set; }

        [ForeignKey("IdgenClasificador")]
        public virtual GenClasificador Clasificador { get; set; }

        [ForeignKey("IdconfigImpacto")]
        public virtual ConfigImpacto Impacto { get; set; }
    }
}
