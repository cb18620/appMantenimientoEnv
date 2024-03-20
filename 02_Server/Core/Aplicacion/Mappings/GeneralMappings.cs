
using Aplicacion.DTOs.Maquinaria;
using Aplicacion.DTOs.Parametricas;
using Aplicacion.DTOs.Segurity;
using Aplicacion.DTOs.Vistas;
using Aplicacion.Features.Aplicacion.Parametricas.Commands;
using AutoMapper;
using Dominio.Entities;
using Dominio.Entities.Seguridad;
using Dominio.Entities.Seguridadmetricas;
using Dominio.Entities.Vistas;

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
            CreateMap<GenClasificador, GenClasificadorDto>();
            CreateMap<GenClasificadortipo, GenClasificadortipoDto>();
            CreateMap<Maquinaria, MaquinariaDto>();
            CreateMap<MaqMaquinaElemento, MaqMaquinaElementoDto>(); 
            CreateMap<MaqElemento, MaqElementoDto>();
            CreateMap<MaqCaractInfra, MaqCaractInfraDto>(); 
            CreateMap<MaqCaractMaquinaria, MaqCaractMaquinariaDto>();   
            CreateMap<MaqCaractVehiculo, MaqCaractVehiculoDto>();
            CreateMap<MaqImpactoRcm, MaqImpactoRcmDto>();
            CreateMap<ConfigImpacto, ConfigImpactoDto>();
            CreateMap<MaqvImpactoRcm, MaqvImpactoRcmDto>();
  
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
            CreateMap<MaqImpactoRcmDto, MaqImpactoRcm>();
            CreateMap<ImpactoItemDto, MaqImpactoRcm>();
            CreateMap<ConfigImpactoDto, ConfigImpacto>();
            CreateMap<MaqvImpactoRcmDto, MaqvImpactoRcm>(); 


            #endregion 
        }
    }
}
