using Aplicacion.DTOs.Segurity;
using Aplicacion.Features.Composicion.Queries;
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

    public class GetClasificadorAreaQuery : IRequest<Response<List<GenClasificadorDto>>>
    {


        public class GetAllAreaQueryHandler : IRequestHandler<GetClasificadorAreaQuery, Response<List<GenClasificadorDto>>>
        {
            private readonly IRepositoryAsync<GenClasificador> _repo;
            private readonly IMapper _mapp;
            public GetAllAreaQueryHandler(IRepositoryAsync<GenClasificador> repositoryAsync, IMapper mapper)
            {
                _repo = repositoryAsync;
                _mapp = mapper;
            }

            public async Task<Response<List<GenClasificadorDto>>> Handle(GetClasificadorAreaQuery request, CancellationToken cancellationToken)

            {
                var _resp = new Response<List<GenClasificadorDto>>();
                try
                {
                    var _resul = await _repo.ListAsync(new GetClasificadorQuerySpecification(), cancellationToken);

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

    public class GetClasificadorQuerySpecification : Specification<GenClasificador>
    {
        public GetClasificadorQuerySpecification()
        {
            Query.Where(x => x.IdgenClasificadortipo == (int)Enums.ClasificadorTipo.area);

        }
    }
}
