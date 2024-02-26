using Aplicacion.DTOs.Parametricas;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using Ardalis.Specification;
using AutoMapper;
using Dominio.Entities.Seguridadmetricas;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Aplicacion.Features.Aplicacion.Parametricas.Queries
{
    public class GetAllPersonaQuery : IRequest<Response<List<PersonaDto>>>
    {
        public class GetAllAdmPersonaQueryHandler : IRequestHandler<GetAllPersonaQuery, Response<List<PersonaDto>>>
        {

            private readonly IRepositoryAsync<GenPersona> _repo;
            private readonly IMapper _mapp;
            public GetAllAdmPersonaQueryHandler(IRepositoryAsync<GenPersona> repo, IMapper mapp)
            {
                _repo = repo;
                _mapp = mapp;
            }

            public async Task<Response<List<PersonaDto>>> Handle(GetAllPersonaQuery request, CancellationToken cancellationToken)
            {
                var oPersonas = await _repo.ListAsync(new GetAllPersonaQuerySpecification(), cancellationToken);
                var mPersonas = _mapp.Map<List<PersonaDto>>(oPersonas);
                return new Response<List<PersonaDto>>() { Data = mPersonas, Message = "Listado", Succeeded = mPersonas.Count <= 0 ? false : true };
            }
        }

        public class GetAllPersonaQuerySpecification : Specification<GenPersona>
        {
            public GetAllPersonaQuerySpecification()
            {

                Query.Include(x => x.Especialidades);
            }
        }

    }
}
