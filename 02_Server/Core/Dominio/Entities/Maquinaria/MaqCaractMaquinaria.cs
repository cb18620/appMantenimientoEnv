using Dominio.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Entities
{
    [Table("maq_caract_maquinaria", Schema = "public")]
    public class MaqCaractMaquinaria : AuditableBaseEntity
    {
        [Key]
        public int IdmaqCaractMaquinaria { get; set; }
        public int Idmaquinaria { get; set; }
        public string Tension { get; set; }
        public string Corriente { get; set; }
        public string Frecuencia { get; set; }
        public string Controlado { get; set; }
        public string Rpm { get; set; }
        public string Temperatura { get; set; }
        public string Caudal { get; set; }
        public string Presion { get; set; }
        public string Vibracion { get; set; } 
        public string Espesor { get; set; }
        public string Potencia { get; set; }
        public string FactorPotencia { get; set; }
    }
}
