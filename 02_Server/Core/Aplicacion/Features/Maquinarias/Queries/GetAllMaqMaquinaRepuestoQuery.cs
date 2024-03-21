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

    public class GetAllMaqMaquinaRepuestoQuery : IRequest<Response<List<MaqMaquinaRepuestoDto>>>
    {
        public int parametroRepuesto { get; set; }


        public class GetAllMaqMaquinaRepuestoQueryHandler : IRequestHandler<GetAllMaqMaquinaRepuestoQuery, Response<List<MaqMaquinaRepuestoDto>>>
        {
            private readonly IRepositoryAsync<MaqMaquinaRepuesto> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllMaqMaquinaRepuestoQueryHandler(IRepositoryAsync<MaqMaquinaRepuesto> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<MaqMaquinaRepuestoDto>>> Handle(GetAllMaqMaquinaRepuestoQuery request, CancellationToken cancellationToken)
            {
                var _MaqMaquinaRepuesto = await _repositoryAsync.ListAsync(new MaqMaquinaRepuestoSpecification(request.parametroRepuesto),cancellationToken);
                var _MaqMaquinaRepuestoDto = _mapper.Map<List<MaqMaquinaRepuestoDto>>(_MaqMaquinaRepuesto);
                return new Response<List<MaqMaquinaRepuestoDto>>(_MaqMaquinaRepuestoDto);
            }


        }

    }

    public class MaqMaquinaRepuestoSpecification : Specification<MaqMaquinaRepuesto>
    {
        public MaqMaquinaRepuestoSpecification(int parametroRepuesto)
        {
            Query.Where(x => x.Idmaquinaria == parametroRepuesto);
            Query.Include(x => x.Maquina)
                  .Include(y => y.Repuesto);
        }
    }
}
