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

    public class GetAllMaqCaractMaquinariaQuery : IRequest<Response<List<MaqCaractMaquinariaDto>>>
    {

        public int parametro3 { get; set; }

        public class GetAllMaqCaractMaquinariaQueryHandler : IRequestHandler<GetAllMaqCaractMaquinariaQuery, Response<List<MaqCaractMaquinariaDto>>>
        {
            private readonly IRepositoryAsync<MaqCaractMaquinaria> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllMaqCaractMaquinariaQueryHandler(IRepositoryAsync<MaqCaractMaquinaria> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<MaqCaractMaquinariaDto>>> Handle(GetAllMaqCaractMaquinariaQuery request, CancellationToken cancellationToken)
            {
                var _MaqCaractMaquinaria = await _repositoryAsync.ListAsync(new MaqCaractMaquinariaSpecification(request.parametro3),cancellationToken);
                var _MaqCaractMaquinariaDto = _mapper.Map<List<MaqCaractMaquinariaDto>>(_MaqCaractMaquinaria);
                return new Response<List<MaqCaractMaquinariaDto>>(_MaqCaractMaquinariaDto);
            }

        }

    }

    public class MaqCaractMaquinariaSpecification : Specification<MaqCaractMaquinaria>
    {
        public MaqCaractMaquinariaSpecification(int parametro3)
        {
            Query.Where(x => x.Idmaquinaria == parametro3);
        }
    }
}
