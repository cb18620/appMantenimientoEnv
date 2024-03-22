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

    public class DeleteMaqMaquinaConsumibleCommand : IRequest<Response<int>>
    {
        public int IdmaqMaquinaConsumible { get; set; }
    }

    public class DeleteMaqMaquinaConsumibleCommandHandler : IRequestHandler<DeleteMaqMaquinaConsumibleCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqMaquinaConsumible> _repositoryAsync;
        public DeleteMaqMaquinaConsumibleCommandHandler(IRepositoryAsync<MaqMaquinaConsumible> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteMaqMaquinaConsumibleCommand request, CancellationToken cancellationToken)
        {
            var _MaqMaquinaConsumible = await _repositoryAsync.GetByIdAsync(request.IdmaqMaquinaConsumible);
            if (_MaqMaquinaConsumible == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_MaqMaquinaConsumible);
                return new Response<int>(_MaqMaquinaConsumible.IdmaqMaquinaConsumible);
            }
        }
    }
}
