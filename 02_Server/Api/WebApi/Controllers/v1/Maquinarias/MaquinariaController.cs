using Aplicacion.Features.Aplicacion.Parametricas.Commands;
using Aplicacion.Features.ClasificadorTipo.Queries;
using Aplicacion.Features.Composicion.Queries;
using Aplicacion.Features.Maquinarias.Commands;
using Aplicacion.Features.Maquinarias.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Maquinarias
{
    [ApiVersion("1.0")]
    public class MaquinariaController : BaseApiController
    {

        [HttpGet("Get")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllMaquinariaQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateMaquinariaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateMaquinariaCommand command)
        {
            if (id != command.Idmaquinaria)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteMaquinariaCommand { Idmaquinaria = id }));
        }
        [HttpGet("area")]
        public async Task<IActionResult> GetlistaArea()
        {
            return Ok(await Mediator.Send(new GetClasificadorAreaQuery()));

        }
        [HttpGet("Proceso")]
        public async Task<IActionResult> GetlistaProceso()
        {
            return Ok(await Mediator.Send(new GetAllProcesoQuery()));

        }

        [HttpGet("Tipomaquinaria")]
        public async Task<IActionResult> GetlistaTipoMaquinaria()
        {
            return Ok(await Mediator.Send(new GetAllTipoQuery()));

        }
        [HttpGet("supervicion")]
        public async Task<IActionResult> GetlistaSupervicion()
        {
            return Ok(await Mediator.Send(new GetAllSupervicionQuery()));

        }
    }
}