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

    public class CreateMaqCaractMaquinariaCommand : IRequest<Response<int>>
    {
        public MaqCaractMaquinariaDto MaqCaractMaquinaria { get; set; }
    }

    public class CreateMaqCaractMaquinariaCommandHandler : IRequestHandler<CreateMaqCaractMaquinariaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqCaractMaquinaria> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateMaqCaractMaquinariaCommandHandler(IRepositoryAsync<MaqCaractMaquinaria> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMaqCaractMaquinariaCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<MaqCaractMaquinaria>(request.MaqCaractMaquinaria);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdmaqCaractMaquinaria);
        }

    }

}
