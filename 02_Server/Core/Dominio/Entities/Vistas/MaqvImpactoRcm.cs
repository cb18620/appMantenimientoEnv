using Dominio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities.Vistas
{
    [Table("maqv_impacto_rcm", Schema = "public")]
    public partial class MaqvImpactoRcm 
    {
        [Key]
        public int Idmaquinaria { get; set; }
        public string DesArea { get; set; }
        public int Area { get; set; }
        public string NombreMaquina { get; set; }
        public string Identificador { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ubicacion { get; set; }
        public string FotoEquipo { get; set; }
        public string DesTipo { get; set; }
        public int? Tipo { get; set; }
        public int Proceso { get; set; }
        public string DesProceso { get; set; }
        public string Funcion { get; set; }
        public string NSerie { get; set; }
        public int? Año { get; set; }
        public string Industria { get; set; }
        public string Proveedor { get; set; }
        public decimal Totalimpacto { get; set; }
        public string Criticidad { get; set; }
        public string Descripcion { get; set; }
        public string Caracteristicas { get; set;}
        public string Fabricante { get; set;}
        public string Origen { get; set;}
        public string RecibidoDe { get; set;}   
        public string EntregadoA { get; set;}   
    }
}
