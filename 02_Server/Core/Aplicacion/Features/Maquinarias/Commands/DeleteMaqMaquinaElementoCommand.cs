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

    public class DeleteMaqMaquinaElementoCommand : IRequest<Response<int>>
    {
        public int IdmaqMaquinaElemento { get; set; }
    }

    public class DeleteMaqMaquinaElementoCommandHandler : IRequestHandler<DeleteMaqMaquinaElementoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqMaquinaElemento> _repositoryAsync;
        public DeleteMaqMaquinaElementoCommandHandler(IRepositoryAsync<MaqMaquinaElemento> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteMaqMaquinaElementoCommand request, CancellationToken cancellationToken)
        {
            var _MaqMaquinaElemento = await _repositoryAsync.GetByIdAsync(request.IdmaqMaquinaElemento);
            if (_MaqMaquinaElemento == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_MaqMaquinaElemento);
                return new Response<int>(_MaqMaquinaElemento.IdmaquinaElemento);
            }
        }

    }
}
