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

    public class DeleteMaqConsumibleCommand : IRequest<Response<int>>
    {
        public int IdmaqConsumible { get; set; }
    }

    public class DeleteMaqConsumibleCommandHandler : IRequestHandler<DeleteMaqConsumibleCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqConsumible> _repositoryAsync;
        public DeleteMaqConsumibleCommandHandler(IRepositoryAsync<MaqConsumible> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteMaqConsumibleCommand request, CancellationToken cancellationToken)
        {
            var _MaqConsumible = await _repositoryAsync.GetByIdAsync(request.IdmaqConsumible);
            if (_MaqConsumible == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_MaqConsumible);
                return new Response<int>(_MaqConsumible.IdmaqConsumible);
            }
        }

    }
}
