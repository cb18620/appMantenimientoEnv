using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs.Maquinaria
{
    public class MaqCaractMaquinariaDto
    {
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
