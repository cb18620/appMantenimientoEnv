using Aplicacion.DTOs.Maquinaria;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Maquinas.Commands
{
    public class CreateMaqImpactoRcmBatchCommand : IRequest<Response<List<int>>>
    {
        public MaqImpactoRcmBatchDto MaqImpactoRcmBatch { get; set; }

        public class CreateMaqImpactoRcmBatchCommandHandler : IRequestHandler<CreateMaqImpactoRcmBatchCommand, Response<List<int>>>
        {
            private readonly IRepositoryAsync<MaqImpactoRcm> _repository;
            private readonly IMapper _mapper;

            public CreateMaqImpactoRcmBatchCommandHandler(IRepositoryAsync<MaqImpactoRcm> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Response<List<int>>> Handle(CreateMaqImpactoRcmBatchCommand request, CancellationToken cancellationToken)
            {
                var maqImpactos = new List<MaqImpactoRcm>();
                foreach (var impactoDto in request.MaqImpactoRcmBatch.Impactos)
                {
                    var maqImpacto = _mapper.Map<MaqImpactoRcm>(impactoDto);
                    maqImpacto.Idmaquinaria = request.MaqImpactoRcmBatch.IdMaquinaria; // Asegura la asignación correcta del ID de maquinaria
                    maqImpactos.Add(maqImpacto);
                }


                // Aquí agregarías los maqImpactos al repositorio
                // Esto dependerá de cómo tu repositorio maneja las adiciones en lote
                await _repository.AddRangeAsync(maqImpactos, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                // Extrayendo los IDs de los impactos recién creados para la respuesta
                var ids = new List<int>(maqImpactos.ConvertAll(impacto => impacto.IdmaqImpactoRcm));

                return new Response<List<int>>(ids);
            }
        }
    }
}
