using Aplicacion.DTOs.Segurity;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities.Seguridad;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.ClasificadorTipo.Commands
{

    public class CreateGenClasificadortipoCommand : IRequest<Response<int>>
    {
        public GenClasificadortipoDto IdgenClasificadortipo { get; set; }
    }

    public class CreateGenClasificadortipoCommandHandler : IRequestHandler<CreateGenClasificadortipoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<GenClasificadortipo> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateGenClasificadortipoCommandHandler(IRepositoryAsync<GenClasificadortipo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateGenClasificadortipoCommand request, CancellationToken cancellationToken)
            {
            var nuevoRegistro = _mapper.Map<GenClasificadortipo>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdgenClasificadortipo);
            }

        
    }

 }

