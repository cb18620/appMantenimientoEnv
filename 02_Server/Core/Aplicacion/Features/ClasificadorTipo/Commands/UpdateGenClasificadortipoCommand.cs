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

namespace Aplicacion.Features.ClasificadorTipo.Commands
{

    public class UpdateGenClasificadortipoCommand : IRequest<Response<int>>
    {
        //TODO: agregar parametros
        public int IdgenClasificadortipo { get; set; }
        public string Descripcion { get; set; }
        public string Valor1 { get; set; }
    }

    public class UpdateGenClasificadortipoCommandHandler : IRequestHandler<UpdateGenClasificadortipoCommand, Response<int>>
    {
        private IRepositoryAsync<GenClasificadortipo> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateGenClasificadortipoCommandHandler(IRepositoryAsync<GenClasificadortipo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateGenClasificadortipoCommand request, CancellationToken cancellationToken)
        {
            var _GenClasificadortipo = await _repositoryAsync.GetByIdAsync(request.IdgenClasificadortipo);
            if (_GenClasificadortipo == null)
            {
                throw new KeyNotFoundException("Registro no encontrado");
            }
            else
            {

                //TODO: agregar mas propiedades
                _GenClasificadortipo.IdgenClasificadortipo = request.IdgenClasificadortipo;
                _GenClasificadortipo.Descripcion = request.Descripcion;
                _GenClasificadortipo.Valor1 = request.Valor1;

                await _repositoryAsync.UpdateAsync(_GenClasificadortipo);
                return new Response<int>(_GenClasificadortipo.IdgenClasificadortipo);
            }
        }
    }

    public class UpdateGenClasificadortipoCommandValidator : AbstractValidator<UpdateGenClasificadortipoCommand>
    {

        public UpdateGenClasificadortipoCommandValidator()
        {
            //TODO: agregar regla de validaciones ..
            //RuleFor(p => p.IdfactFacturacabecera)
            //    .NotEmpty().WithMessage("textomensaje0")
            //    .MaximumLength(120).WithMessage("textomensaje");
        }
    }
}
