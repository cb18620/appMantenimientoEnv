using Aplicacion.DTOs.Maquinaria;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using Ardalis.Specification;
using AutoMapper;
using Dominio.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Maquinarias.Queries
{

    public class GetAllMaqCaractVehiculoQuery : IRequest<Response<List<MaqCaractVehiculoDto>>>
    {
        public int parametro1 { get; set; }

        public class GetAllMaqCaractVehiculoQueryHandler : IRequestHandler<GetAllMaqCaractVehiculoQuery, Response<List<MaqCaractVehiculoDto>>>
        {
            private readonly IRepositoryAsync<MaqCaractVehiculo> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllMaqCaractVehiculoQueryHandler(IRepositoryAsync<MaqCaractVehiculo> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<MaqCaractVehiculoDto>>> Handle(GetAllMaqCaractVehiculoQuery request, CancellationToken cancellationToken)
            {
                var _MaqCaractVehiculo = await _repositoryAsync.ListAsync(new MaqCaractVehiculoSpecification(request.parametro1),cancellationToken);
                var _MaqCaractVehiculoDto = _mapper.Map<List<MaqCaractVehiculoDto>>(_MaqCaractVehiculo);
                return new Response<List<MaqCaractVehiculoDto>>(_MaqCaractVehiculoDto);
            }

            
        }

    }

    public class MaqCaractVehiculoSpecification : Specification<MaqCaractVehiculo>
    {
        public MaqCaractVehiculoSpecification(int parametro1)
        {
            Query.Where(x => x.Idmaquinaria == parametro1);
        }
    }
}
