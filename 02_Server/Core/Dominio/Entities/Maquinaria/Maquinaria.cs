using Dominio.Common;
using Dominio.Entities.Seguridad;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Entities
{
    [Table("maq_maquinaria", Schema = "public")]
    public class Maquinaria : AuditableBaseEntity
    {
        [Key]
        public int Idmaquinaria { get; set; }
        public string NombreMaquina { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public string Identificador { get; set; }
        public int Area { get; set; }
        [ForeignKey("Area")]
        public GenClasificador Areas { get; set; } 
        public string Caracteristicas { get; set; }
        public string Marca { get; set; }
        public int Tipo { get; set; }
        [ForeignKey("Tipo")]
        public GenClasificador Tipos { get; set; } = null!;
        public string Ubicacion { get; set; }
        public string FotoEquipo { get; set; }
        public int? Año { get; set; }
        public string EntregadoA { get; set; }
        public string Funcion { get; set; }
        public string NSerie { get; set; }
        public string Fabricante { get; set; }
        public string Industria { get; set; }
        public string Proveedor { get; set; }
        public string Origen { get; set; }
        public string RecibidoDe { get; set; }
        public int Proceso { get; set; }
        [ForeignKey("Proceso")]
        public GenClasificador Procesos { get; set; } 

        public virtual ICollection<MaqMaquinaElemento> MaqMaquinaElementos { get; set; }

        public Maquinaria()
        {
            MaqMaquinaElementos = new HashSet<MaqMaquinaElemento>();
        }
    }
}
