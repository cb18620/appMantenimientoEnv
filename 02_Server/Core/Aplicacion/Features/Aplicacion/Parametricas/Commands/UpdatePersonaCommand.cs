using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities.Seguridadmetricas;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Aplicacion.Parametricas.Commands
{
    public class UpdatePersonaCommand : IRequest<Response<int>>
    {
        public int Idpersonal { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Especialidad { get; set; }
        public int? Telefono { get; set; }
        public string Ci { get; set; }
        public string Correo { get; set; }
        public string Foto { get; set; }
    }

    public class UpdatePersonaCommandHandler : IRequestHandler<UpdatePersonaCommand, Response<int>>
    {
        private IRepositoryAsync<GenPersona> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdatePersonaCommandHandler(IRepositoryAsync<GenPersona> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdatePersonaCommand request, CancellationToken cancellationToken)
        {
            var _Persona = await _repositoryAsync.GetByIdAsync(request.Idpersonal);
            if (_Persona == null)
            {
                throw new KeyNotFoundException("Registro no encontrado");
            }
            else
            {
                _Persona.Idpersonal = request.Idpersonal;
                _Persona.Nombre = request.Nombre;
                _Persona.Apellido = request.Apellido;
                _Persona.Especialidad = request.Especialidad;
                _Persona.Telefono = request.Telefono;
                _Persona.Ci = request.Ci;
                _Persona.Correo = request.Correo;
                _Persona.Foto = request.Foto;

                await _repositoryAsync.UpdateAsync(_Persona);
                return new Response<int>(_Persona.Idpersonal);
            }
        }
    }

    public class UpdatePersonaCommandValidator : AbstractValidator<UpdatePersonaCommand>
    {
        public UpdatePersonaCommandValidator()
        {
            //TODO: agregar regla de validaciones ..
            //RuleFor(p => p.IdfactFacturacabecera)
            //    .NotEmpty().WithMessage("textomensaje0")
            //    .MaximumLength(120).WithMessage("textomensaje");
        }
    }
}
