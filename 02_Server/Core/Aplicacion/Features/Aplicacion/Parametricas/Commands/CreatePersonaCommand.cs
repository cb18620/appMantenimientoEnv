using Aplicacion.DTOs.Parametricas;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities.Seguridadmetricas;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Aplicacion.Parametricas.Commands
{

    public class CreatePersonaCommand : IRequest<Response<int>>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Especialidad { get; set; }
        public int? Telefono { get; set; }
        public string Ci { get; set; }
        public string Correo { get; set; }
        public string Foto { get; set; }
    }

    public class CreatePersonaCommandHandler : IRequestHandler<CreatePersonaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<GenPersona> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreatePersonaCommandHandler(IRepositoryAsync<GenPersona> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<GenPersona>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.Idpersonal);
        }
    }

    public class CreatePersonaCommandValidator : AbstractValidator<CreatePersonaCommand>
    {
        public CreatePersonaCommandValidator()
        {
           /* RuleFor(p => p._persona.Nombres)
                .NotEmpty().WithMessage("{PropertyName} no pude ser vacio")
                .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");*/
        }
    }

    
    
}
