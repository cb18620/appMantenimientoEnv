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

    public class DeleteMaqCaractVehiculoCommand : IRequest<Response<int>>
    {
        public int IdmaqCaractVehiculo { get; set; }
    }

    public class DeleteMaqCaractVehiculoCommandHandler : IRequestHandler<DeleteMaqCaractVehiculoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqCaractVehiculo> _repositoryAsync;
        public DeleteMaqCaractVehiculoCommandHandler(IRepositoryAsync<MaqCaractVehiculo> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteMaqCaractVehiculoCommand request, CancellationToken cancellationToken)
        {
            var _MaqCaractVehiculo = await _repositoryAsync.GetByIdAsync(request.IdmaqCaractVehiculo);
            if (_MaqCaractVehiculo == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_MaqCaractVehiculo);
                return new Response<int>(_MaqCaractVehiculo.IdmaqCaractVehiculo);
            }
        }

    }
}
