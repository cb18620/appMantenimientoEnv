using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Maquinarias.Commands
{

    public class UpdateMaqCaractVehiculoCommand : IRequest<Response<int>>
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
        //TODO: agregar parametros
    }

    public class UpdateMaqCaractVehiculoCommandHandler : IRequestHandler<UpdateMaqCaractVehiculoCommand, Response<int>>
    {
        private IRepositoryAsync<MaqCaractVehiculo> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateMaqCaractVehiculoCommandHandler(IRepositoryAsync<MaqCaractVehiculo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateMaqCaractVehiculoCommand request, CancellationToken cancellationToken)
        {
            var _MaqCaractVehiculo = await _repositoryAsync.GetByIdAsync(request.IdmaqCaractVehiculo);
            if (_MaqCaractVehiculo == null)
            {
                throw new KeyNotFoundException("Registro no encontrado");
            }
            else
            {
                //TODO: agregar mas propiedades
                _MaqCaractVehiculo.IdmaqCaractVehiculo = request.IdmaqCaractVehiculo;
                _MaqCaractVehiculo.Idmaquinaria = request.Idmaquinaria;
                _MaqCaractVehiculo.Puertas = request.Traccion;
                _MaqCaractVehiculo.Ruedas = request.Ruedas;
                _MaqCaractVehiculo.Cilindros = request.Cilindros;
                _MaqCaractVehiculo.Direccion = request.Direccion;
                _MaqCaractVehiculo.Transmision = request.Transmision;
                _MaqCaractVehiculo.Conbustible = request.Conbustible;
                _MaqCaractVehiculo.Potencia = request.Potencia;
                _MaqCaractVehiculo.Motor = request.Motor;
                _MaqCaractVehiculo.Capacidad = request.Capacidad;

                await _repositoryAsync.UpdateAsync(_MaqCaractVehiculo);
                return new Response<int>(_MaqCaractVehiculo.IdmaqCaractVehiculo);
            }
        }

      
    }

    public class UpdateMaqCaractVehiculoCommandValidator : AbstractValidator<UpdateMaqCaractVehiculoCommand>
    {

        public UpdateMaqCaractVehiculoCommandValidator()
        {
            //TODO: agregar regla de validaciones ..
            //RuleFor(p => p.IdfactFacturacabecera)
            //    .NotEmpty().WithMessage("textomensaje0")
            //    .MaximumLength(120).WithMessage("textomensaje");
        }
    }
}
