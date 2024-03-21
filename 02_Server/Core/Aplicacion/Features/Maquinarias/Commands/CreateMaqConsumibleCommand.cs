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

    public class CreateMaqConsumibleCommand : IRequest<Response<int>>
    {
        public MaqConsumibleDto MaqConsumible { get; set; }
    }

    public class CreateMaqConsumibleCommandHandler : IRequestHandler<CreateMaqConsumibleCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqConsumible> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateMaqConsumibleCommandHandler(IRepositoryAsync<MaqConsumible> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMaqConsumibleCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<MaqConsumible>(request.MaqConsumible);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdmaqConsumible);
        }

    }

    public class CreateMaqConsumibleCommandValidator : AbstractValidator<CreateMaqConsumibleCommand>
    {
        public CreateMaqConsumibleCommandValidator()
        {
            //RuleFor(p => p.tabla.campo)
            //    .NotEmpty().WithMessage("{PropertyName} no pude ser vacio")
            //    .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}
