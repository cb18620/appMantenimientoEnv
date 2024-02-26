using Aplicacion.Features.ClasificadorTipo.Commands;
using Aplicacion.Features.ClasificadorTipo.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Clasificador
{
    [ApiVersion("1.0")]
    [Authorize]
    public class GenClasificadortipoController : BaseApiController
    {

        [HttpGet("GetAllGenClasificadortipo")]
        [Authorize]
        public async Task<IActionResult> GetAllGenClasificadortipo()
        {
            return Ok(await Mediator.Send(new GetAllGenClasificadortipoQuery()));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateGenClasificadortipoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateGenClasificadortipoCommand command)
        {
            if (id != command.IdgenClasificadortipo)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteGenClasificadortipoCommand { IdgenClasificadortipo = id }));
        }
    }
}
