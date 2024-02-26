using Aplicacion.DTOs.Maquinaria;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Maquinarias.Commands
{
   
    public class CreateMaqCaractInfraCommand : IRequest<Response<int>>
    {
        public MaqCaractInfraDto MaqCaractInfra { get; set; }
    }

    public class CreateMaqCaractInfraCommandHandler : IRequestHandler<CreateMaqCaractInfraCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqCaractInfra> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateMaqCaractInfraCommandHandler(IRepositoryAsync<MaqCaractInfra> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMaqCaractInfraCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<MaqCaractInfra>(request.MaqCaractInfra);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdmaqCaractInfra);
        }

    }

}
