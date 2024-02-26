using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
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

    public class UpdateMaqElementoCommand : IRequest<Response<int>>
    {
        public int Idelemento { get; set; }
        //TODO: agregar parametros
    }

    public class UpdateMaqElementoCommandHandler : IRequestHandler<UpdateMaqElementoCommand, Response<int>>
    {
        private IRepositoryAsync<MaqElemento> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateMaqElementoCommandHandler(IRepositoryAsync<MaqElemento> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateMaqElementoCommand request, CancellationToken cancellationToken)
        {
            var _MaqElemento = await _repositoryAsync.GetByIdAsync(request.Idelemento);
            if (_MaqElemento == null)
            {
                throw new KeyNotFoundException("Registro no encontrado");
            }
            else
            {
                _MaqElemento.Idelemento = request.Idelemento;
                //TODO: agregar mas propiedades

                await _repositoryAsync.UpdateAsync(_MaqElemento);
                return new Response<int>(_MaqElemento.Idelemento);
            }
        }

    }
}
