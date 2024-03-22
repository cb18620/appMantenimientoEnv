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

    public class CreateMaqMaquinaConsumibleCommand : IRequest<Response<int>>
    {
        public MaqMaquinaConsumibleDto MaqMaquinaConsumible { get; set; }
    }

    public class CreateMaqMaquinaConsumibleCommandHandler : IRequestHandler<CreateMaqMaquinaConsumibleCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqMaquinaConsumible> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateMaqMaquinaConsumibleCommandHandler(IRepositoryAsync<MaqMaquinaConsumible> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMaqMaquinaConsumibleCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<MaqMaquinaConsumible>(request.MaqMaquinaConsumible);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdmaqMaquinaConsumible);
        }

  
    }

 
}
