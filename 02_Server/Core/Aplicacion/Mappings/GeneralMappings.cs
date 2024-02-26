
using Aplicacion.DTOs.Maquinaria;
using Aplicacion.DTOs.Parametricas;
using Aplicacion.DTOs.Segurity;
using Aplicacion.Features.Aplicacion.Parametricas.Commands;
using AutoMapper;
using Dominio.Entities;
using Dominio.Entities.Seguridad;
using Dominio.Entities.Seguridadmetricas;

namespace Aplicacion.Mappings
{
    public class GeneralMappings : Profile
    {
        public GeneralMappings()
        {
            //TODO: Agregar aqui el registro de mapeo para obtenion de consultas  direccion  EntidadDominio --> ModeloDto
            #region QueryDto
            CreateMap<SegvUsuario, SegUsuarioDto>();
            CreateMap<GenPersona, PersonaDto>();
            CreateMap<Maquinaria, MaquinariaDto>();
            CreateMap<GenClasificador, GenClasificadorDto>();
            CreateMap<GenClasificadortipo, GenClasificadortipoDto>();

            CreateMap<Maquinaria, MaquinariaDto>();
            CreateMap<MaqMaquinaElemento, MaqMaquinaElementoDto>(); 
            CreateMap<MaqElemento, MaqElementoDto>();
            CreateMap<MaqCaractInfra, MaqCaractInfraDto>(); 
            CreateMap<MaqCaractMaquinaria, MaqCaractMaquinariaDto>();   
            CreateMap<MaqCaractVehiculo, MaqCaractVehiculoDto>();   
            /**///**

            #endregion

            //TODO: Agregar aqui el registro de mapeo para ejecucion de comandos  direccion  ModeloDto --> EntidadDominio Ej. : CreateMap<ProductoDto, CapProducto>();
            #region Commands
            CreateMap<PersonaDto, GenPersona>();
            CreateMap<MaquinariaDto, Maquinaria>();
            CreateMap<CreatePersonaCommand, GenPersona>();
            CreateMap<GenClasificadortipoDto, GenClasificadortipo>();
            CreateMap<GenClasificadorDto, GenClasificador>();

            CreateMap<MaquinariaDto, Maquinaria>();
            CreateMap<MaqMaquinaElementoDto, MaqMaquinaElemento>();
            CreateMap<MaqElementoDto, MaqElemento>();
            CreateMap<MaqCaractInfraDto , MaqCaractInfra>();
            CreateMap<MaqCaractMaquinariaDto, MaqCaractMaquinaria>();
            CreateMap<MaqCaractVehiculoDto, MaqCaractVehiculo>();

            #endregion 
        }
    }
}
