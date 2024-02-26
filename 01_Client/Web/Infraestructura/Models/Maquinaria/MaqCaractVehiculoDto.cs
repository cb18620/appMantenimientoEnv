using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs.Maquinaria
{
    public class MaqCaractVehiculoDto
    {
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
        public bool VerDetalle { get; set; }
    }
}
