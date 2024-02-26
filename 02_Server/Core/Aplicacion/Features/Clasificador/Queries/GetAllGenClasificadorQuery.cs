using Aplicacion.DTOs.Segurity;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using Ardalis.Specification;
using AutoMapper;
using Dominio.Entities.Seguridad;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Clasificador.Queries
{

    public class GetAllGenClasificadorQuery : IRequest<Response<List<GenClasificadorDto>>>
    {
  


        public class GetAllGenClasificadorQueryHandler : IRequestHandler<GetAllGenClasificadorQuery, Response<List<GenClasificadorDto>>>
        {
            private readonly IRepositoryAsync<GenClasificador> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllGenClasificadorQueryHandler(IRepositoryAsync<GenClasificador> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<GenClasificadorDto>>> Handle(GetAllGenClasificadorQuery request, CancellationToken cancellationToken)
            {
                var _GenClasificador = await _repositoryAsync.ListAsync(new GenClasificadorSpecification(),cancellationToken);
                var _GenClasificadorDto = _mapper.Map<List<GenClasificadorDto>>(_GenClasificador);
                return new Response<List<GenClasificadorDto>>(_GenClasificadorDto);
            }

        }

    }

    public class GenClasificadorSpecification : Specification<GenClasificador>
    {
        public GenClasificadorSpecification()
            {
                Query.Include(x => x.Tipo);
            }
    }
}
