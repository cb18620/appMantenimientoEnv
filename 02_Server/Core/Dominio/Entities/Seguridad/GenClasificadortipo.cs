using Dominio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities.Seguridad
{
    [Table("gen_clasificadortipo", Schema = "public")]
    public class GenClasificadortipo : AuditableBaseEntity
    {
        [Key]
        public int IdgenClasificadortipo { get; set; } 
        public string Descripcion { get; set; }    
        public string Valor1 { get; set; } 
    }
}
