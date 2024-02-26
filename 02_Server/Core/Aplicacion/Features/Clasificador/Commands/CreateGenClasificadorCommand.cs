﻿using Aplicacion.DTOs.Segurity;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities.Seguridad;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Clasificador.Commands
{

    public class CreateGenClasificadorCommand : IRequest<Response<int>>
    {
        public GenClasificadorDto GenClasificador { get; set; }
    }

    public class CreateGenClasificadorCommandHandler : IRequestHandler<CreateGenClasificadorCommand, Response<int>>
    {
        private readonly IRepositoryAsync<GenClasificador> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateGenClasificadorCommandHandler(IRepositoryAsync<GenClasificador> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateGenClasificadorCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<GenClasificador>(request.GenClasificador);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdgenClasificador);
        }

      
    }

    public class CreateGenClasificadorCommandValidator : AbstractValidator<CreateGenClasificadorCommand>
    {
        public CreateGenClasificadorCommandValidator()
        {
           /*RuleFor(p => p.tabla.campo)
                .NotEmpty().WithMessage("{PropertyName} no pude ser vacio")
                .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");*/
        }
    }
}
