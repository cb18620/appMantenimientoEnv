using Aplicacion.Features.Maquinarias.Commands;
using Aplicacion.Features.Maquinarias.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Maquinarias
{
    [ApiVersion("1.0")]
    public class MaqElementoController : BaseApiController
    {
        [HttpGet("Get")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllMaqElementoQuery()));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateMaqElementoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteMaqElementoCommand { Idelemento = id }));
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateMaqElementoCommand command)
        {
            if (id != command.Idelemento)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
