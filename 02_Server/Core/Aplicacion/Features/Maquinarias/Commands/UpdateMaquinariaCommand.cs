using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Entities.Seguridad;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Maquinarias.Commands
{

    public class UpdateMaquinariaCommand : IRequest<Response<int>>
    {
        public int Idmaquinaria { get; set; }
        public string NombreMaquina { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public string Identificador { get; set; }
        public int Area { get; set; }
        public string Caracteristicas { get; set; }
        public string Marca { get; set; }
        public int Tipo { get; set; }
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
        //TODO: agregar parametros
    }

    public class UpdateMaquinariaCommandHandler : IRequestHandler<UpdateMaquinariaCommand, Response<int>>
    {
        private IRepositoryAsync<Maquinaria> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateMaquinariaCommandHandler(IRepositoryAsync<Maquinaria> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateMaquinariaCommand request, CancellationToken cancellationToken)
        {
            var _Maquinaria = await _repositoryAsync.GetByIdAsync(request.Idmaquinaria);
            if (_Maquinaria == null)
            {
                throw new KeyNotFoundException("Registro no encontrado");
            }
            else
            {
                _Maquinaria.Idmaquinaria = request.Idmaquinaria;
                _Maquinaria.NombreMaquina = request.NombreMaquina;
                _Maquinaria.Descripcion = request.Descripcion;
                _Maquinaria.Modelo = request.Modelo;
                _Maquinaria.Identificador = request.Identificador;
                _Maquinaria.Area = request.Area;
                _Maquinaria.Caracteristicas = request.Caracteristicas;
                _Maquinaria.Marca = request.Marca;
                _Maquinaria.Tipo = request.Tipo;
                _Maquinaria.Ubicacion = request.Ubicacion;
                _Maquinaria.FotoEquipo = request.FotoEquipo;
                _Maquinaria.Año = request.Año;
                _Maquinaria.EntregadoA = request.EntregadoA;
                _Maquinaria.Funcion = request.Funcion;
                _Maquinaria.NSerie = request.NSerie;
                _Maquinaria.Fabricante = request.Fabricante;
                _Maquinaria.Industria = request.Proveedor;
                _Maquinaria.Origen = request.Origen;
                _Maquinaria.RecibidoDe = request.RecibidoDe;
                _Maquinaria.Proceso = request.Proceso;




                //TODO: agregar mas propiedades

                await _repositoryAsync.UpdateAsync(_Maquinaria);
                return new Response<int>(_Maquinaria.Idmaquinaria);
            }
        }

    }

}
