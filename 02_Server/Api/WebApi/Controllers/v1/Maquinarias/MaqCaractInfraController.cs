using Aplicacion.Features.Maquinarias.Commands;
using Aplicacion.Features.Maquinarias.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Maquinarias
{
    [ApiVersion("1.0")]
    public class MaqCaractInfraController : BaseApiController
    {
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetAllMaqCaractInfraQuery
            {
                parametro2 = id
            }));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateMaqCaractInfraCommand command)
        {
            return Ok(await Mediator.Send(command));
           
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateMaqCaractInfraCommand command)
        {
            if (id != command.IdmaqCaractInfra)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteMaqCaractInfraCommand { IdmaqCaractInfra = id }));
        }
    }
}
