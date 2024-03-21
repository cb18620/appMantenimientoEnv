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

    public class GetAllMaqRepuestoQuery : IRequest<Response<List<MaqRepuestoDto>>>
    {


        public class GetAllMaqRepuestoQueryHandler : IRequestHandler<GetAllMaqRepuestoQuery, Response<List<MaqRepuestoDto>>>
        {
            private readonly IRepositoryAsync<MaqRepuesto> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllMaqRepuestoQueryHandler(IRepositoryAsync<MaqRepuesto> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<MaqRepuestoDto>>> Handle(GetAllMaqRepuestoQuery request, CancellationToken cancellationToken)
            {
                var _MaqRepuesto = await _repositoryAsync.ListAsync();
                var _MaqRepuestoDto = _mapper.Map<List<MaqRepuestoDto>>(_MaqRepuesto);
                return new Response<List<MaqRepuestoDto>>(_MaqRepuestoDto);
            }


        }

    }
}
