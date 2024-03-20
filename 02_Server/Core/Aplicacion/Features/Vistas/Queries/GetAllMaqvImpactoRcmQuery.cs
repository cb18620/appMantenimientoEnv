using Aplicacion.DTOs.Vistas;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using Ardalis.Specification;
using AutoMapper;
using Dominio.Entities.Vistas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Vistas.Queries
{

    public class GetAllMaqvImpactoRcmQuery : IRequest<Response<List<MaqvImpactoRcmDto>>>
    {



        public class GetAllMaqvImpactoRcmQueryHandler : IRequestHandler<GetAllMaqvImpactoRcmQuery, Response<List<MaqvImpactoRcmDto>>>
        {
            private readonly IRepositoryAsync<MaqvImpactoRcm> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllMaqvImpactoRcmQueryHandler(IRepositoryAsync<MaqvImpactoRcm> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<MaqvImpactoRcmDto>>> Handle(GetAllMaqvImpactoRcmQuery request, CancellationToken cancellationToken)
            {
                var _MaqvImpactoRcm = await _repositoryAsync.ListAsync(new MaqvImpactoRcmSpecification(),cancellationToken);
                var _MaqvImpactoRcmDto = _mapper.Map<List<MaqvImpactoRcmDto>>(_MaqvImpactoRcm);
                return new Response<List<MaqvImpactoRcmDto>>(_MaqvImpactoRcmDto);
            }

          
        }

    }

    public class MaqvImpactoRcmSpecification : Specification<MaqvImpactoRcm>
    {
        public MaqvImpactoRcmSpecification()
        {

        }
    }
}
