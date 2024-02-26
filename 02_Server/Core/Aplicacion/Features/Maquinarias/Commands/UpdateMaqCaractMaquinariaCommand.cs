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

    public class UpdateMaqCaractMaquinariaCommand : IRequest<Response<int>>
    {
        //TODO: agregar parametros
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

    public class UpdateMaqCaractMaquinariaCommandHandler : IRequestHandler<UpdateMaqCaractMaquinariaCommand, Response<int>>
    {
        private IRepositoryAsync<MaqCaractMaquinaria> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateMaqCaractMaquinariaCommandHandler(IRepositoryAsync<MaqCaractMaquinaria> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateMaqCaractMaquinariaCommand request, CancellationToken cancellationToken)
        {
            var _MaqCaractMaquinaria = await _repositoryAsync.GetByIdAsync(request.IdmaqCaractMaquinaria);
            if (_MaqCaractMaquinaria == null)
            {
                throw new KeyNotFoundException("Registro no encontrado");
            }
            else
            {
                _MaqCaractMaquinaria.IdmaqCaractMaquinaria = request.IdmaqCaractMaquinaria;
                _MaqCaractMaquinaria.Idmaquinaria = request.Idmaquinaria;
                _MaqCaractMaquinaria.Tension = request.Tension;
                _MaqCaractMaquinaria.Corriente = request.Corriente;
                _MaqCaractMaquinaria.Frecuencia = request.Frecuencia;
                _MaqCaractMaquinaria.Controlado = request.Controlado;
                _MaqCaractMaquinaria.Rpm = request.Rpm;
                _MaqCaractMaquinaria.Temperatura = request.Temperatura;
                _MaqCaractMaquinaria.Caudal = request.Caudal;
                _MaqCaractMaquinaria.Presion = request.Presion;
                _MaqCaractMaquinaria.Vibracion = request.Vibracion;
                _MaqCaractMaquinaria.Espesor = request.Espesor;
                _MaqCaractMaquinaria.Potencia = request.Potencia;
                _MaqCaractMaquinaria.FactorPotencia = request.FactorPotencia;
              
                //TODO: agregar mas propiedades

                await _repositoryAsync.UpdateAsync(_MaqCaractMaquinaria);
                return new Response<int>(_MaqCaractMaquinaria.IdmaqCaractMaquinaria);
            }
        }

        
    }

    public class UpdateMaqCaractMaquinariaCommandValidator : AbstractValidator<UpdateMaqCaractMaquinariaCommand>
    {

        public UpdateMaqCaractMaquinariaCommandValidator()
        {
            //TODO: agregar regla de validaciones ..
            //RuleFor(p => p.IdfactFacturacabecera)
            //    .NotEmpty().WithMessage("textomensaje0")
            //    .MaximumLength(120).WithMessage("textomensaje");
        }
    }
}
