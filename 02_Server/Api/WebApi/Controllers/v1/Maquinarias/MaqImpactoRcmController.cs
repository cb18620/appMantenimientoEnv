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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllMaqImpactoRcm(int id)
        {
            return Ok(await Mediator.Send(new GetAllMaqImpactoRcmQuery
            {
                parametrorcm = id 
            }));
        }

        [HttpGet("Get")]
        [Authorize]
        public async Task<IActionResult> GetImpactoRCM()
        {
            return Ok(await Mediator.Send(new GetAllImpactoRCMQuery()));
        }
        [HttpPost("CreateBatchMaqImpactoRcm")]
        [Authorize]
        public async Task<IActionResult> CreateBatchMaqImpactoRcm([FromBody] CreateMaqImpactoRcmBatchCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateMaqImpactoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteMaqImpactoCommand { IdMaqImpacto = id }));
        }

    }
}
