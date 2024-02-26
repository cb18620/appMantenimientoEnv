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

    public class GetAllMaqElementoQuery : IRequest<Response<List<MaqElementoDto>>>
    {


        public class GetAllMaqElementoQueryHandler : IRequestHandler<GetAllMaqElementoQuery, Response<List<MaqElementoDto>>>
        {
            private readonly IRepositoryAsync<MaqElemento> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllMaqElementoQueryHandler(IRepositoryAsync<MaqElemento> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<MaqElementoDto>>> Handle(GetAllMaqElementoQuery request, CancellationToken cancellationToken)
            {
                var _MaqElemento = await _repositoryAsync.ListAsync(new MaqElementoSpecification(), cancellationToken);
                var _MaqElementoDto = _mapper.Map<List<MaqElementoDto>>(_MaqElemento);
                return new Response<List<MaqElementoDto>>(_MaqElementoDto);
            }
        }

    }

    public class MaqElementoSpecification : Specification<MaqElemento>
    {
        public MaqElementoSpecification()
        {

        }
    }
}
