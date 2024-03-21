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

    public class GetAllMaqConsumibleQuery : IRequest<Response<List<MaqConsumibleDto>>>
    {



        public class GetAllMaqConsumibleQueryHandler : IRequestHandler<GetAllMaqConsumibleQuery, Response<List<MaqConsumibleDto>>>
        {
            private readonly IRepositoryAsync<MaqConsumible> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllMaqConsumibleQueryHandler(IRepositoryAsync<MaqConsumible> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<MaqConsumibleDto>>> Handle(GetAllMaqConsumibleQuery request, CancellationToken cancellationToken)
            {
                var _MaqConsumible = await _repositoryAsync.ListAsync(new MaqConsumibleSpecification(),cancellationToken);
                var _MaqConsumibleDto = _mapper.Map<List<MaqConsumibleDto>>(_MaqConsumible);
                return new Response<List<MaqConsumibleDto>>(_MaqConsumibleDto);
            }

         
        }

    }

    public class MaqConsumibleSpecification : Specification<MaqConsumible>
    {
        public MaqConsumibleSpecification()
        {
            //Query.Where(x => x.Campo1 >= Parametro1 && x.campo2 <= Parametro2).Take(20);
        }
    }
}
