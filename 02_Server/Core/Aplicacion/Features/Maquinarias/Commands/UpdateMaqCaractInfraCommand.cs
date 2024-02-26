using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Maquinarias.Commands
{

    public class UpdateMaqCaractInfraCommand : IRequest<Response<int>>
    {
        public int IdmaqCaractInfra { get; set; }
        public int Idmaquinaria { get; set; }
        public string Puertas { get; set; }
        public string Ventanas { get; set; }
        public string Luminarias { get; set; }
        public string Tomas { get; set; }
        public string Largo { get; set; }
        public string Ancho { get; set; }
        public string Altura { get; set; }
    }

    public class UpdateMaqCaractInfraCommandHandler : IRequestHandler<UpdateMaqCaractInfraCommand, Response<int>>
    {
        private IRepositoryAsync<MaqCaractInfra> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateMaqCaractInfraCommandHandler(IRepositoryAsync<MaqCaractInfra> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateMaqCaractInfraCommand request, CancellationToken cancellationToken)
        {
            var _MaqCaractInfra = await _repositoryAsync.GetByIdAsync(request.IdmaqCaractInfra);
            if (_MaqCaractInfra == null)
            {
                throw new KeyNotFoundException("Registro no encontrado");
            }
            else
            {
                _MaqCaractInfra.IdmaqCaractInfra = request.IdmaqCaractInfra;
                _MaqCaractInfra.Idmaquinaria = request.Idmaquinaria;
                _MaqCaractInfra.Puertas = request.Puertas;
                _MaqCaractInfra.Ventanas = request.Ventanas;
                _MaqCaractInfra.Luminarias = request.Luminarias;
                _MaqCaractInfra.Tomas = request.Tomas;
                _MaqCaractInfra.Largo = request.Largo;
                _MaqCaractInfra.Ancho = request.Ancho;
                _MaqCaractInfra.Altura = request.Altura;


                await _repositoryAsync.UpdateAsync(_MaqCaractInfra);
                return new Response<int>(_MaqCaractInfra.IdmaqCaractInfra);
            }
        }

    }

    public class UpdateMaqCaractInfraCommandValidator : AbstractValidator<UpdateMaqCaractInfraCommand>
    {

        public UpdateMaqCaractInfraCommandValidator()
        {

        }
    }
}
