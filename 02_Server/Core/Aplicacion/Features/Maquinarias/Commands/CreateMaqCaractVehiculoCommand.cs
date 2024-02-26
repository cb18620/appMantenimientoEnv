using Aplicacion.DTOs.Maquinaria;
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

    public class CreateMaqCaractVehiculoCommand : IRequest<Response<int>>
    {
        public MaqCaractVehiculoDto MaqCaractVehiculo { get; set; }
    }

    public class CreateMaqCaractVehiculoCommandHandler : IRequestHandler<CreateMaqCaractVehiculoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqCaractVehiculo> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateMaqCaractVehiculoCommandHandler(IRepositoryAsync<MaqCaractVehiculo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMaqCaractVehiculoCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<MaqCaractVehiculo>(request.MaqCaractVehiculo);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdmaqCaractVehiculo);
        }

    }

}
