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

    public class UpdateMaqRepuestoCommand : IRequest<Response<int>>
    {
        public int IdmaqRepuesto { get; set; }
        public string Detalle { get; set; }
        public string Codigo { get; set; }
        public string? Valor1 { get; set; }
        public int? Cantidad { get; set; }
        public int? Valor2 { get; set; }
    }

    public class UpdateMaqRepuestoCommandHandler : IRequestHandler<UpdateMaqRepuestoCommand, Response<int>>
    {
        private IRepositoryAsync<MaqRepuesto> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateMaqRepuestoCommandHandler(IRepositoryAsync<MaqRepuesto> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateMaqRepuestoCommand request, CancellationToken cancellationToken)
        {
            var _MaqRepuesto = await _repositoryAsync.GetByIdAsync(request.IdmaqRepuesto);
            if (_MaqRepuesto == null)
            {
                throw new KeyNotFoundException("Registro no encontrado");
            }
            else
            {
                _MaqRepuesto.IdmaqRepuesto = request.IdmaqRepuesto;
                _MaqRepuesto.Detalle = request.Detalle;
                _MaqRepuesto.Codigo = request.Codigo;
                _MaqRepuesto.Valor1 = request.Valor1;
                _MaqRepuesto.Cantidad = request.Cantidad;
                _MaqRepuesto.Valor2 = request.Valor2;
                //TODO: agregar mas propiedades

                await _repositoryAsync.UpdateAsync(_MaqRepuesto);
                return new Response<int>(_MaqRepuesto.IdmaqRepuesto);
            }
        }

     
    }

    public class UpdateMaqRepuestoCommandValidator : AbstractValidator<UpdateMaqRepuestoCommand>
    {

        public UpdateMaqRepuestoCommandValidator()
        {
            //TODO: agregar regla de validaciones ..
            //RuleFor(p => p.IdfactFacturacabecera)
            //    .NotEmpty().WithMessage("textomensaje0")
            //    .MaximumLength(120).WithMessage("textomensaje");
        }
    }
}
