using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using Dominio.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Maquinarias.Commands
{

    public class DeleteMaqImpactoCommand : IRequest<Response<int>>
    {
        public int IdMaqImpacto { get; set; }
    }

    public class DeleteMaqImpactoCommandHandler : IRequestHandler<DeleteMaqImpactoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqImpactoRcm> _repositoryAsync;
        public DeleteMaqImpactoCommandHandler(IRepositoryAsync<MaqImpactoRcm> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteMaqImpactoCommand request, CancellationToken cancellationToken)
        {
            var _MaqImpacto = await _repositoryAsync.GetByIdAsync(request.IdMaqImpacto);
            if (_MaqImpacto == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_MaqImpacto);
                return new Response<int>(_MaqImpacto.IdmaqImpactoRcm);
            }
        }

    }
}
