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

    public class DeleteMaqCaractMaquinariaCommand : IRequest<Response<int>>
    {
        public int IdmaqCaractMaquinaria { get; set; }
    }

    public class DeleteMaqCaractMaquinariaCommandHandler : IRequestHandler<DeleteMaqCaractMaquinariaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqCaractMaquinaria> _repositoryAsync;
        public DeleteMaqCaractMaquinariaCommandHandler(IRepositoryAsync<MaqCaractMaquinaria> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteMaqCaractMaquinariaCommand request, CancellationToken cancellationToken)
        {
            var _MaqCaractMaquinaria = await _repositoryAsync.GetByIdAsync(request.IdmaqCaractMaquinaria);
            if (_MaqCaractMaquinaria == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_MaqCaractMaquinaria);
                return new Response<int>(_MaqCaractMaquinaria.IdmaqCaractMaquinaria);
            }
        }

    
    }
}
