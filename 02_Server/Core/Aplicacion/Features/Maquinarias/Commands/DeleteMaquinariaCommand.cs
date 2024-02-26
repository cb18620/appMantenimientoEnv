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

    public class DeleteMaquinariaCommand : IRequest<Response<int>>
    {
        public int Idmaquinaria { get; set; }
    }

    public class DeleteMaquinariaCommandHandler : IRequestHandler<DeleteMaquinariaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Maquinaria> _repositoryAsync;
        public DeleteMaquinariaCommandHandler(IRepositoryAsync<Maquinaria> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteMaquinariaCommand request, CancellationToken cancellationToken)
        {
            var _Maquinaria = await _repositoryAsync.GetByIdAsync(request.Idmaquinaria);
            if (_Maquinaria == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_Maquinaria);
                return new Response<int>(_Maquinaria.Idmaquinaria);
            }
        }

    }
}
