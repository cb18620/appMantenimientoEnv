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

    public class GetAllMaqMaquinaElementoQuery : IRequest<Response<List<MaqMaquinaElementoDto>>>
    {
        //ver detalle
        public int parametroelemento {  get; set; } 
        public class GetAllMaqMaquinaElementoQueryHandler : IRequestHandler<GetAllMaqMaquinaElementoQuery, Response<List<MaqMaquinaElementoDto>>>
        {
            private readonly IRepositoryAsync<MaqMaquinaElemento> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllMaqMaquinaElementoQueryHandler(IRepositoryAsync<MaqMaquinaElemento> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<MaqMaquinaElementoDto>>> Handle(GetAllMaqMaquinaElementoQuery request, CancellationToken cancellationToken)
            {
                var _MaqMaquinaElemento = await _repositoryAsync.ListAsync(new MaqMaquinaElementoSpecification(request.parametroelemento), cancellationToken);
                var _MaqMaquinaElementoDto = _mapper.Map<List<MaqMaquinaElementoDto>>(_MaqMaquinaElemento);
                return new Response<List<MaqMaquinaElementoDto>>(_MaqMaquinaElementoDto);
            }
        }

    }

    public class MaqMaquinaElementoSpecification : Specification<MaqMaquinaElemento>
    {
        public MaqMaquinaElementoSpecification(int parametroelemento)
        {
            Query.Include(x => x.Idmaquinaria == parametroelemento);
        
        }
    }
}
