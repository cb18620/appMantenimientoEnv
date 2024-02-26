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

    public class CreateMaquinariaCommand : IRequest<Response<int>>
    {
        
        public MaquinariaDto _Maquinaria { get; set; } 
    }


    public class CreateMaquinariaCommandHandler : IRequestHandler<CreateMaquinariaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Maquinaria> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateMaquinariaCommandHandler(IRepositoryAsync<Maquinaria> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMaquinariaCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Maquinaria>(request._Maquinaria);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.Idmaquinaria);
        }

        
    }

    public class CreateMaquinariaCommandValidator : AbstractValidator<CreateMaquinariaCommand>
    {
        public CreateMaquinariaCommandValidator()
        {
            //RuleFor(p => p.tabla.campo)
            //    .NotEmpty().WithMessage("{PropertyName} no pude ser vacio")
            //    .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}
