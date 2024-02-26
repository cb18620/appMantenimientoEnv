using Dominio.Entities.Seguridad;

namespace Aplicacion.DTOs.Parametricas
{
    public class PersonaDto
    {
        public int Idpersonal { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Especialidad { get; set; }
        public GenClasificador Especialidades { get; set; }
        public int? Telefono { get; set; }
        public string Ci { get; set; }
        public string Correo { get; set; }
        public string Foto { get; set; }
    }
}
