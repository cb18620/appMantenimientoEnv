using Aplicacion.Features.Clasificador.Commands;
using Aplicacion.Features.Clasificador.Queries;
using Aplicacion.Features.ClasificadorTipo.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Clasificador
{
    [ApiVersion("1.0")]
    [Authorize]
    public class ClasificadorController : BaseApiController
    {

        [HttpGet("GetAllGenClasificador")]
        [Authorize]
        public async Task<IActionResult> GetAllGenClasificador()
        {
            return Ok(await Mediator.Send(new GetAllGenClasificadorQuery()));
        }


        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post(CreateGenClasificadorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateGenClasificadorCommand command)
        {
            if (id != command.IdgenClasificador)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteGenClasificadorCommand { IdgenClasificador = id }));
        }
        [HttpGet("rcm")]
        public async Task<IActionResult> GetlistaRcm()
        {
            return Ok(await Mediator.Send(new GetAllClasificadorRcmQuery()));

        }
    }
}
