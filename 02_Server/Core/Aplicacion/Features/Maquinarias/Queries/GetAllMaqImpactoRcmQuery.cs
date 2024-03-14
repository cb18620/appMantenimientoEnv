﻿using Aplicacion.DTOs.Maquinaria;
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

    public class GetAllMaqImpactoRcmQuery : IRequest<Response<List<MaqImpactoRcmDto>>>
    {
   


        public class GetAllMaqImpactoRcmQueryHandler : IRequestHandler<GetAllMaqImpactoRcmQuery, Response<List<MaqImpactoRcmDto>>>
        {
            private readonly IRepositoryAsync<MaqImpactoRcm> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllMaqImpactoRcmQueryHandler(IRepositoryAsync<MaqImpactoRcm> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<MaqImpactoRcmDto>>> Handle(GetAllMaqImpactoRcmQuery request, CancellationToken cancellationToken)
            {
                var _MaqImpactoRcmList = await _repositoryAsync.ListAsync(new MaqImpactoRcmSpecification(),cancellationToken);
                var _MaqImpactoRcmDtoList = _mapper.Map<List<MaqImpactoRcmDto>>(_MaqImpactoRcmList);
                return new Response<List<MaqImpactoRcmDto>>(_MaqImpactoRcmDtoList);
            }
        }

    }

    public class MaqImpactoRcmSpecification : Specification<MaqImpactoRcm>
    {
        public MaqImpactoRcmSpecification()
        {
            Query.Include(x => x.Maquinaria)
              .Include(x => x.Clasificador)
              .Include(x => x.Impacto);
        }
    }
}


