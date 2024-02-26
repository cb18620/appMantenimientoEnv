using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using Dominio.Entities.Seguridad;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Aplicacion.Features.ClasificadorTipo.Commands
{

    public class DeleteGenClasificadortipoCommand : IRequest<Response<int>>
    {
        public int IdgenClasificadortipo { get; set; }
    }

    public class DeleteGenClasificadortipoCommandHandler : IRequestHandler<DeleteGenClasificadortipoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<GenClasificadortipo> _repositoryAsync;
        public DeleteGenClasificadortipoCommandHandler(IRepositoryAsync<GenClasificadortipo> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteGenClasificadortipoCommand request, CancellationToken cancellationToken)
        {
            var _GenClasificadortipo = await _repositoryAsync.GetByIdAsync(request.IdgenClasificadortipo);
            if (_GenClasificadortipo == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_GenClasificadortipo);
                return new Response<int>(_GenClasificadortipo.IdgenClasificadortipo);
            }
        }

    }
}
