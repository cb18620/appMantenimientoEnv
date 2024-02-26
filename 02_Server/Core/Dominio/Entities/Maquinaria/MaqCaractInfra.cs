using Dominio.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Entities
{
    [Table("maq_caract_infra", Schema = "public")]
    public class MaqCaractInfra : AuditableBaseEntity
    {
        [Key]
        public int IdmaqCaractInfra { get; set; }
        public int Idmaquinaria { get; set; }
        public string Puertas { get; set; }
        public string Ventanas { get; set; }
        public string Luminarias { get; set; }
        public string Tomas { get; set; }
        public string Largo { get; set; }
        public string Ancho { get; set; }
        public string Altura { get; set; }
    }
}
