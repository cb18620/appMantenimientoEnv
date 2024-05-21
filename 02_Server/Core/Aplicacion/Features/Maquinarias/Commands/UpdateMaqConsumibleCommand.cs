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

    public class UpdateMaqConsumibleCommand : IRequest<Response<int>>
    {
        public int IdmaqConsumible { get; set; }
        public string Codigo { get; set; }
        public string Detalle { get; set; }
        public string Cantidad { get; set; }
    }

    public class UpdateMaqConsumibleCommandHandler : IRequestHandler<UpdateMaqConsumibleCommand, Response<int>>
    {
        private IRepositoryAsync<MaqConsumible> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateMaqConsumibleCommandHandler(IRepositoryAsync<MaqConsumible> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateMaqConsumibleCommand request, CancellationToken cancellationToken)
        {
            var _MaqConsumible = await _repositoryAsync.GetByIdAsync(request.IdmaqConsumible);
            if (_MaqConsumible == null)
            {
                throw new KeyNotFoundException("Registro no encontrado");
            }
            else
            {
                _MaqConsumible.IdmaqConsumible = request.IdmaqConsumible;
                _MaqConsumible.Codigo = request.Codigo;
                _MaqConsumible.Detalle = request.Detalle;
                _MaqConsumible.Cantidad = request.Cantidad;
                //TODO: agregar mas propiedades

                await _repositoryAsync.UpdateAsync(_MaqConsumible);
                return new Response<int>(_MaqConsumible.IdmaqConsumible);
            }
        }

    
    }

    public class UpdateMaqConsumibleCommandValidator : AbstractValidator<UpdateMaqConsumibleCommand>
    {

        public UpdateMaqConsumibleCommandValidator()
        {
            //TODO: agregar regla de validaciones ..
            //RuleFor(p => p.IdfactFacturacabecera)
            //    .NotEmpty().WithMessage("textomensaje0")
            //    .MaximumLength(120).WithMessage("textomensaje");
        }
    }
}
