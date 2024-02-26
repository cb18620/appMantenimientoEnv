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

    public class DeleteMaqElementoCommand : IRequest<Response<int>>
    {
        public int Idelemento { get; set; }
    }

    public class DeleteMaqElementoCommandHandler : IRequestHandler<DeleteMaqElementoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqElemento> _repositoryAsync;
        public DeleteMaqElementoCommandHandler(IRepositoryAsync<MaqElemento> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteMaqElementoCommand request, CancellationToken cancellationToken)
        {
            var _MaqElemento = await _repositoryAsync.GetByIdAsync(request.Idelemento);
            if (_MaqElemento == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_MaqElemento);
                return new Response<int>(_MaqElemento.Idelemento);
            }
        }

    }
}
