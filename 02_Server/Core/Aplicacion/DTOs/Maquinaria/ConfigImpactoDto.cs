using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs.Maquinaria
{
    public class ConfigImpactoDto
    {
        public int IdconfigImpacto { get; set; }
        public decimal? Valor { get; set; }
        public string Nombre { get; set; }
    }
}
