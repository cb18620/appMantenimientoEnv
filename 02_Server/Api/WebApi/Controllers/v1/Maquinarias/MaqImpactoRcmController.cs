using Aplicacion.Features.Aplicacion.Parametricas.Commands;
using Aplicacion.Features.Clasificador.Commands;
using Aplicacion.Features.ClasificadorTipo.Queries;
using Aplicacion.Features.Composicion.Queries;
using Aplicacion.Features.Maquinarias.Commands;
using Aplicacion.Features.Maquinarias.Queries;
using Aplicacion.Features.Maquinas.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Maquinarias
{
    [ApiVersion("1.0")]
    [Authorize]
    public class MaqImpactoRcmController : BaseApiController
    {

        [HttpGet("GetAllMaqImpactoRcm")]
        public async Task<IActionResult> GetAllMaqImpactoRcm()
        {
            return Ok(await Mediator.Send(new GetAllMaqImpactoRcmQuery()));
        }
        [HttpPost("CreateBatchMaqImpactoRcm")]
        [Authorize]
        public async Task<IActionResult> CreateBatchMaqImpactoRcm([FromBody] CreateMaqImpactoRcmBatchCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
