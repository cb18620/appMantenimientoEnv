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

    public class DeleteMaqMaquinaRepuestoCommand : IRequest<Response<int>>
    {
        public int IdmaqMaquinaRepuesto { get; set; }
    }

    public class DeleteMaqMaquinaRepuestoCommandHandler : IRequestHandler<DeleteMaqMaquinaRepuestoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqMaquinaRepuesto> _repositoryAsync;
        public DeleteMaqMaquinaRepuestoCommandHandler(IRepositoryAsync<MaqMaquinaRepuesto> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteMaqMaquinaRepuestoCommand request, CancellationToken cancellationToken)
        {
            var _MaqMaquinaRepuesto = await _repositoryAsync.GetByIdAsync(request.IdmaqMaquinaRepuesto);
            if (_MaqMaquinaRepuesto == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_MaqMaquinaRepuesto);
                return new Response<int>(_MaqMaquinaRepuesto.IdmaqMaquinaRepuesto);
            }
        }

    }
}
