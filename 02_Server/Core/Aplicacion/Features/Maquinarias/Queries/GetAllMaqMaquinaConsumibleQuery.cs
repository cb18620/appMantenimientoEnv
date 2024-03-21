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

    public class GetAllMaqMaquinaConsumibleQuery : IRequest<Response<List<MaqMaquinaConsumibleDto>>>
    {
        public int parametroComsumible { get; set; }

        public class GetAllMaqMaquinaConsumibleQueryHandler : IRequestHandler<GetAllMaqMaquinaConsumibleQuery, Response<List<MaqMaquinaConsumibleDto>>>
        {
            private readonly IRepositoryAsync<MaqMaquinaConsumible> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllMaqMaquinaConsumibleQueryHandler(IRepositoryAsync<MaqMaquinaConsumible> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<MaqMaquinaConsumibleDto>>> Handle(GetAllMaqMaquinaConsumibleQuery request, CancellationToken cancellationToken)
            {
                var _MaqMaquinaConsumible = await _repositoryAsync.ListAsync(new MaqMaquinaConsumibleSpecification(request.parametroComsumible),cancellationToken);
                var _MaqMaquinaConsumibleDto = _mapper.Map<List<MaqMaquinaConsumibleDto>>(_MaqMaquinaConsumible);
                return new Response<List<MaqMaquinaConsumibleDto>>(_MaqMaquinaConsumibleDto);
            }

  
        }

    }

    public class MaqMaquinaConsumibleSpecification : Specification<MaqMaquinaConsumible>
    {
        public MaqMaquinaConsumibleSpecification(int parametroComsumible)
        {
            Query.Where(x => x.Idmaquinaria == parametroComsumible);
            Query.Include(x => x.Maquina)
                  .Include(y => y.Consumible);
        }
    }
}
