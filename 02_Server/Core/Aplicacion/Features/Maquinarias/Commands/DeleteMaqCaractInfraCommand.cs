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

    public class DeleteMaqCaractInfraCommand : IRequest<Response<int>>
    {
        public int IdmaqCaractInfra { get; set; }
    }

    public class DeleteMaqCaractInfraCommandHandler : IRequestHandler<DeleteMaqCaractInfraCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqCaractInfra> _repositoryAsync;
        public DeleteMaqCaractInfraCommandHandler(IRepositoryAsync<MaqCaractInfra> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteMaqCaractInfraCommand request, CancellationToken cancellationToken)
        {
            var _MaqCaractInfra = await _repositoryAsync.GetByIdAsync(request.IdmaqCaractInfra);
            if (_MaqCaractInfra == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_MaqCaractInfra);
                return new Response<int>(_MaqCaractInfra.IdmaqCaractInfra);
            }
        }

        
    }
}
