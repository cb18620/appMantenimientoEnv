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

    public class DeleteMaqRepuestoCommand : IRequest<Response<int>>
    {
        public int IdmaqRepuesto { get; set; }
    }

    public class DeleteMaqRepuestoCommandHandler : IRequestHandler<DeleteMaqRepuestoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqRepuesto> _repositoryAsync;
        public DeleteMaqRepuestoCommandHandler(IRepositoryAsync<MaqRepuesto> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteMaqRepuestoCommand request, CancellationToken cancellationToken)
        {
            var _MaqRepuesto = await _repositoryAsync.GetByIdAsync(request.IdmaqRepuesto);
            if (_MaqRepuesto == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_MaqRepuesto);
                return new Response<int>(_MaqRepuesto.IdmaqRepuesto);
            }
        }
    }
}
