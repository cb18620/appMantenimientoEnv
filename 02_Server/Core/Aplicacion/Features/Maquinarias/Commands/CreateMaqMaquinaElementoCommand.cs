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
    public class CreateMaqMaquinaElementoCommand : IRequest<Response<int>>
    {
        public MaqMaquinaElementoDto maqElemento { get; set; }
    }

    public class CreateMaqMaquinaElementoCommandHandler : IRequestHandler<CreateMaqMaquinaElementoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqMaquinaElemento> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateMaqMaquinaElementoCommandHandler(IRepositoryAsync<MaqMaquinaElemento> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMaqMaquinaElementoCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<MaqMaquinaElemento>(request.maqElemento);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdmaquinaElemento);
        }

    }
}
