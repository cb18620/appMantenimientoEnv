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

    public class GetAllMaqCaractInfraQuery : IRequest<Response<List<MaqCaractInfraDto>>>
    {
        public int parametro2 { get; set; }

        public class GetAllMaqCaractInfraQueryHandler : IRequestHandler<GetAllMaqCaractInfraQuery, Response<List<MaqCaractInfraDto>>>
        {
            private readonly IRepositoryAsync<MaqCaractInfra> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllMaqCaractInfraQueryHandler(IRepositoryAsync<MaqCaractInfra> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<MaqCaractInfraDto>>> Handle(GetAllMaqCaractInfraQuery request, CancellationToken cancellationToken)
            {
                var _MaqCaractInfra = await _repositoryAsync.ListAsync(new MaqCaractInfraSpecification(request.parametro2), cancellationToken);
                var _MaqCaractInfraDto = _mapper.Map<List<MaqCaractInfraDto>>(_MaqCaractInfra);
                return new Response<List<MaqCaractInfraDto>>(_MaqCaractInfraDto);
            }

        }

    }

    public class MaqCaractInfraSpecification : Specification<MaqCaractInfra>
    {
        public MaqCaractInfraSpecification(int parametro2)
        {
            Query.Where(x => x.Idmaquinaria == parametro2);
        }
    }

}
