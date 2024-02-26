
using Aplicacion.Features.Aplicacion.Parametricas.Commands;
using Aplicacion.Features.Aplicacion.Parametricas.Queries;
using Aplicacion.Features.Composicion.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Aplicacion
{
  
    [ApiVersion("1.0")]
    [Authorize]
    public class PersonaController : BaseApiController
    {

        [HttpGet("GetAllPersona")]
        public async Task<IActionResult> GetAllPersona()
        {
            return Ok(await Mediator.Send(new GetAllPersonaQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePersonaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdatePersonaCommand command)
        {
            if (id != command.Idpersonal)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePersonaCommand { Idpersonal = id }));
        }

        [HttpGet("especialidad")]
        public async Task<IActionResult> GetlistadoColor()
        {
            return Ok(await Mediator.Send(new GetClasificadorEspecialidadQuery()));

        }

    }
}
