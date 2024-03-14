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

    public class GetAllConfigImpactoQuery : IRequest<Response<List<ConfigImpactoDto>>>
    {


        public class GetAllConfigImpactoQueryHandler : IRequestHandler<GetAllConfigImpactoQuery, Response<List<ConfigImpactoDto>>>
        {
            private readonly IRepositoryAsync<ConfigImpacto> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllConfigImpactoQueryHandler(IRepositoryAsync<ConfigImpacto> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<ConfigImpactoDto>>> Handle(GetAllConfigImpactoQuery request, CancellationToken cancellationToken)
            {
                var _ConfigImpacto = await _repositoryAsync.ListAsync(new ConfigImpactoSpecification(),cancellationToken);
                var _ConfigImpactoDto = _mapper.Map<List<ConfigImpactoDto>>(_ConfigImpacto);
                return new Response<List<ConfigImpactoDto>>(_ConfigImpactoDto);
            }

  
        }

    }

    public class ConfigImpactoSpecification : Specification<ConfigImpacto>
    {
        public ConfigImpactoSpecification()
        {
            
        }
    }
}
