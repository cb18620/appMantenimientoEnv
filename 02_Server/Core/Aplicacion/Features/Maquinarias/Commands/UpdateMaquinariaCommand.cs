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

    public class UpdateMaquinariaCommand : IRequest<Response<int>>
    {
        public int Idmaquinaria { get; set; }
        //TODO: agregar parametros
    }

    public class UpdateMaquinariaCommandHandler : IRequestHandler<UpdateMaquinariaCommand, Response<int>>
    {
        private IRepositoryAsync<Maquinaria> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateMaquinariaCommandHandler(IRepositoryAsync<Maquinaria> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateMaquinariaCommand request, CancellationToken cancellationToken)
        {
            var _Maquinaria = await _repositoryAsync.GetByIdAsync(request.Idmaquinaria);
            if (_Maquinaria == null)
            {
                throw new KeyNotFoundException("Registro no encontrado");
            }
            else
            {
                _Maquinaria.Idmaquinaria = request.Idmaquinaria;
                //TODO: agregar mas propiedades

                await _repositoryAsync.UpdateAsync(_Maquinaria);
                return new Response<int>(_Maquinaria.Idmaquinaria);
            }
        }

    }

}
