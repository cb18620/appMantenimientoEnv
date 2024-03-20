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

    public class CreateMaqImpactoCommand : IRequest<Response<int>>
    {
        public MaqImpactoRcmDto maqImpacto { get; set; }
    }

    public class CreateMaqImpactoCommandHandler : IRequestHandler<CreateMaqImpactoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<MaqImpactoRcm> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateMaqImpactoCommandHandler(IRepositoryAsync<MaqImpactoRcm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMaqImpactoCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<MaqImpactoRcm>(request.maqImpacto);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdmaqImpactoRcm);
        }

        
    }

}
