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

    public class CreateMaqMaquinaRepuestoCommand : IRequest<Response<int>>
    {
        public MaqMaquinaRepuestoDto MaqMaquinaRepuesto { get; set; }
    }

    public class CreateMaqMaquinaRepuestoCommandHandler : IRequestHandler<CreateMaqMaquinaRepuestoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqMaquinaRepuesto> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateMaqMaquinaRepuestoCommandHandler(IRepositoryAsync<MaqMaquinaRepuesto> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMaqMaquinaRepuestoCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<MaqMaquinaRepuesto>(request.MaqMaquinaRepuesto);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdmaqMaquinaRepuesto);
        }


    }


}
