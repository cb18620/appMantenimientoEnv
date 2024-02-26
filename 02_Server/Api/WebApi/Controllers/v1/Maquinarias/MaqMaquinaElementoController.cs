using Aplicacion.Features.Clasificador.Queries;
using Aplicacion.Features.Maquinarias.Commands;
using Aplicacion.Features.Maquinarias.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Maquinarias
{
    [ApiVersion("1.0")]
    [Authorize]
    public class MaqMaquinaElementoController : BaseApiController
    {

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetElemento(int id)
        {
            return Ok(await Mediator.Send(new GetAllMaqMaquinaElementoQuery
            {
                parametroelemento = id
            }));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateMaqMaquinaElementoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
