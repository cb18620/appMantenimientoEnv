using Dominio.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Entities
{
    [Table("maq_caract_vehiculo", Schema = "public")]
    public class MaqCaractVehiculo : AuditableBaseEntity
    { 
        [Key] 
        public int IdmaqCaractVehiculo { get; set; }
        public int Idmaquinaria { get; set; }
        public string Puertas { get; set; }
        public string Traccion { get; set; }
        public string Ruedas { get; set; }
        public string Cilindros { get; set; }
        public string Direccion { get; set; }
        public string Transmision { get; set; }
        public string Conbustible { get; set; }
        public string Potencia { get; set; }
        public string Motor { get; set; }
        public string Capacidad { get; set; } 
    }
}
