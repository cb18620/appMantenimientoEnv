using Aplicacion.DTOs.Maquinaria;
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

    public class CreateMaqRepuestoCommand : IRequest<Response<int>>
    {
        public MaqRepuestoDto MaqRepuesto { get; set; }
    }

    public class CreateMaqRepuestoCommandHandler : IRequestHandler<CreateMaqRepuestoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqRepuesto> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateMaqRepuestoCommandHandler(IRepositoryAsync<MaqRepuesto> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMaqRepuestoCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<MaqRepuesto>(request.MaqRepuesto);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdmaqRepuesto);
        }

    }

    public class CreateMaqRepuestoCommandValidator : AbstractValidator<CreateMaqRepuestoCommand>
    {
        public CreateMaqRepuestoCommandValidator()
        {
            //RuleFor(p => p.tabla.campo)
            //    .NotEmpty().WithMessage("{PropertyName} no pude ser vacio")
            //    .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}
