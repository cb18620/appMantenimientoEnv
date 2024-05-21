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

namespace Aplicacion.Features.ClasificadorTipo.Queries
{

    public class GetAllSupervicionQuery : IRequest<Response<List<GenClasificadorDto>>>
    {

        public class GetAllSupervicionQueryHandler : IRequestHandler<GetAllSupervicionQuery, Response<List<GenClasificadorDto>>>
        {
            private readonly IRepositoryAsync<GenClasificador> _repo;
            private readonly IMapper _mapp;
            public GetAllSupervicionQueryHandler(IRepositoryAsync<GenClasificador> repositoryAsync, IMapper mapper)
            {
                _repo = repositoryAsync;
                _mapp = mapper;
            }

            public async Task<Response<List<GenClasificadorDto>>> Handle(GetAllSupervicionQuery request, CancellationToken cancellationToken)

            {
                var _resp = new Response<List<GenClasificadorDto>>();
                try
                {
                    var _resul = await _repo.ListAsync(new SupervicionSpecification(), cancellationToken);

                    _resp.Message = _resul.Count > 0 ? String.Format(Resources.Generic.Resource.QuerySucces, _resul.Count) : Resources.Generic.Resource.QueryBad;
                    _resp.Succeeded = _resul.Count > 0;
                    _resp.Data = _resul.Count > 0 ? _mapp.Map<List<GenClasificadorDto>>(_resul) : null;
                }
                catch (Exception e)
                {
                    _resp.Message = e.Message;
                    _resp.Succeeded = false;
                }

                return _resp;
            }
        }
    }

    public class SupervicionSpecification : Specification<GenClasificador>
    {
        public SupervicionSpecification()
        {
            Query.Where(x => x.IdgenClasificadortipo == (int)Enums.ClasificadorTipo.supervision);
        }
    }
}
