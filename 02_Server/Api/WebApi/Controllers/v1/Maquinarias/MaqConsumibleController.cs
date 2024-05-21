using Aplicacion.Features.Maquinarias.Commands;
using Aplicacion.Features.Maquinarias.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Maquinarias
{
    [ApiVersion("1.0")]
    public class MaqConsumibleController : BaseApiController
    {
        [HttpGet("Get")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllMaqConsumibleQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateMaqConsumibleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteMaqConsumibleCommand { IdmaqConsumible = id }));
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateMaqConsumibleCommand command)
        {
            if (id != command.IdmaqConsumible)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
