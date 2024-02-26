using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities.Seguridad;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Clasificador.Commands
{

    public class UpdateGenClasificadorCommand : IRequest<Response<int>>
    {
       
        //TODO: agregar parametros
        public int IdgenClasificador { get; set; }
        public int IdgenClasificadortipo { get; set; }
        public string Descripcion { get; set; }
        public string Valor2 { get; set; }
        public string Valor3 { get; set; }
        public string Otro { get; set; }
    }

    public class UpdateGenClasificadorCommandHandler : IRequestHandler<UpdateGenClasificadorCommand, Response<int>>
    {
        private IRepositoryAsync<GenClasificador> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateGenClasificadorCommandHandler(IRepositoryAsync<GenClasificador> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateGenClasificadorCommand request, CancellationToken cancellationToken)
        {
            var _GenClasificador = await _repositoryAsync.GetByIdAsync(request.IdgenClasificador);
            if (_GenClasificador == null)
            {
                throw new KeyNotFoundException("Registro no encontrado");
            }
            else
            {

                //TODO: agregar mas propiedades
                _GenClasificador.IdgenClasificador = request.IdgenClasificador;
                _GenClasificador.IdgenClasificadortipo = request.IdgenClasificadortipo;
                _GenClasificador.Descripcion = request.Descripcion;
                _GenClasificador.Valor2 = request.Valor2;
                _GenClasificador.Valor3 = request.Valor3;
                _GenClasificador.Otro = request.Otro;


                await _repositoryAsync.UpdateAsync(_GenClasificador);
                return new Response<int>(_GenClasificador.IdgenClasificador);
            }
        }

       
    }

    public class UpdateGenClasificadorCommandValidator : AbstractValidator<UpdateGenClasificadorCommand>
    {

        public UpdateGenClasificadorCommandValidator()
        {
            //TODO: agregar regla de validaciones ..
            //RuleFor(p => p.IdfactFacturacabecera)
            //    .NotEmpty().WithMessage("textomensaje0")
            //    .MaximumLength(120).WithMessage("textomensaje");
        }
    }
}
