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
    public class GetAllMaquinariaQuery : IRequest<Response<List<MaquinariaDto>>>
    {
        public class GetAllMaquinariaQueryHandler : IRequestHandler<GetAllMaquinariaQuery, Response<List<MaquinariaDto>>>
        {
            private readonly IRepositoryAsync<Maquinaria> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllMaquinariaQueryHandler(IRepositoryAsync<Maquinaria> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }
            public async Task<Response<List<MaquinariaDto>>> Handle(GetAllMaquinariaQuery request, CancellationToken cancellationToken)
            {
                var _Maquinaria = await _repositoryAsync.ListAsync(new MaquinariaSpecification());
                var _MaquinariaDto = _mapper.Map<List<MaquinariaDto>>(_Maquinaria);
                return new Response<List<MaquinariaDto>>(_MaquinariaDto);
            }
        }
    }
    public class MaquinariaSpecification : Specification<Maquinaria>
    {
        public MaquinariaSpecification()
        {

            Query.Include(x => x.MaqMaquinaElementos)
                    .ThenInclude(mme => mme.MaqElement)
                 .Include(a => a.Areas)
                 .Include(m => m.Tipos)
                 .Include(pr => pr.Procesos);

        }
    }
}