using Dominio.Entities.Seguridad;
using Infraestructura.Models.Clasificador;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs.Maquinaria
{
    public class MaquinariaDto
    {
        public int Idmaquinaria { get; set; }
        public string Descripcion { get; set; }
        public string NombreMaquina { get; set; }
        public string Modelo { get; set; }
        public string Identificador { get; set; }
        public int Area { get; set; }
        public GenClasificador Areas { get; set; }
        public string Caracteristicas { get; set; }
        public string Marca { get; set; }
        public int Tipo { get; set; }
        public GenClasificador Tipos { get; set; }
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
        public GenClasificador Procesos { get; set; } 
        public bool VerDetalle { get; set; }
    }
}
