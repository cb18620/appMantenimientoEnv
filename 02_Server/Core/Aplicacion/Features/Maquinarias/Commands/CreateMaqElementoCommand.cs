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

    public class CreateMaqElementoCommand : IRequest<Response<int>>
    {
        public MaqElementoDto MaqElemento { get; set; }
    }

    public class CreateMaqElementoCommandHandler : IRequestHandler<CreateMaqElementoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqElemento> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateMaqElementoCommandHandler(IRepositoryAsync<MaqElemento> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMaqElementoCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<MaqElemento>(request.MaqElemento);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.Idelemento);
        }

    }

    public class CreateMaqElementoCommandValidator : AbstractValidator<CreateMaqElementoCommand>
    {
        public CreateMaqElementoCommandValidator()
        {
            //RuleFor(p => p.tabla.campo)
            //    .NotEmpty().WithMessage("{PropertyName} no pude ser vacio")
            //    .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}
