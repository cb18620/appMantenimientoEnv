using Aplicacion.Features.Maquinarias.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Maquinarias
{
    [ApiVersion("1.0")]
    [Authorize]
    public class MaqMaquinaRepuestoController : BaseApiController
    {

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetRepuesto(int id)
        {
            return Ok(await Mediator.Send(new GetAllMaqMaquinaRepuestoQuery
            {
                parametroRepuesto = id
            }));
        }
    }
}
