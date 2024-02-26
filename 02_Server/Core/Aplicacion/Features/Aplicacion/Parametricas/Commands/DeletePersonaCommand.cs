
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Entities.Seguridadmetricas;

namespace Aplicacion.Features.Aplicacion.Parametricas.Commands
{

    public class DeletePersonaCommand : IRequest<Response<int>>
    {
        public int Idpersonal { get; set; }
    }

    public class DeletePersonaCommandHandler : IRequestHandler<DeletePersonaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<GenPersona> _repositoryAsync;
        public DeletePersonaCommandHandler(IRepositoryAsync<GenPersona> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
        {
            var _Persona = await _repositoryAsync.GetByIdAsync(request.Idpersonal);
            if (_Persona == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_Persona);
                return new Response<int>(_Persona.Idpersonal);
            }
        }
    }
}
