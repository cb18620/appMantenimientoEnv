using Dominio.Common;
using Dominio.Entities.Seguridad;
using Dominio.Settings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entities.Seguridadmetricas
{
    [Table("gen_persona", Schema = "public")]
    public class GenPersona : AuditableBaseEntity
    {
        [Key]
        public int Idpersonal { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Especialidad { get; set; }
        [ForeignKey("Especialidad")]
        public GenClasificador Especialidades { get; set; } = null!;
        public int? Telefono { get; set; }
        public string Ci { get; set; }
        public string Correo { get; set; }
        public string Foto { get; set; }

    }
}
