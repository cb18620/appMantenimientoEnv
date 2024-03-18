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

    public class GetAllImpactoRCMQuery : IRequest<Response<List<MaqImpactoRcmDto>>>
    {
        public class GetAllImpactoRCMQueryHandler : IRequestHandler<GetAllImpactoRCMQuery, Response<List<MaqImpactoRcmDto>>>
        {
            private readonly IRepositoryAsync<MaqImpactoRcm> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllImpactoRCMQueryHandler(IRepositoryAsync<MaqImpactoRcm> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<MaqImpactoRcmDto>>> Handle(GetAllImpactoRCMQuery request, CancellationToken cancellationToken)
            {
                var _ImpactoRCM = await _repositoryAsync.ListAsync(new ImpactoRCMSpecification(),cancellationToken);
                var _ImpactoRCMDto = _mapper.Map<List<MaqImpactoRcmDto>>(_ImpactoRCM);
                return new Response<List<MaqImpactoRcmDto>>(_ImpactoRCMDto);
            }
        
        }

    }

    public class ImpactoRCMSpecification : Specification<MaqImpactoRcm>
    {
        public ImpactoRCMSpecification()
        {
            
        }
    }
}
