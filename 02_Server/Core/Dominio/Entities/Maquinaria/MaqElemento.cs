using Dominio.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Entities
{
    [Table("maq_elemento", Schema = "public")]
    public class MaqElemento : AuditableBaseEntity
    {
        [Key]
        public int Idelemento { get; set; }
        public string Descripcion { get; set; }
        public string Funcion { get; set; }
        
    }
}

