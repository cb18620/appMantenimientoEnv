using Aplicacion.Features.Clasificador.Queries;
using Aplicacion.Features.Vistas.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Vistas
{
    [ApiVersion("1.0")]
    [Authorize]
    public class VImpactoRcmController : BaseApiController
    {
        [HttpGet("impacto")]
        [Authorize]
        public async Task<IActionResult> GetAllImpacto()
        {
            return Ok(await Mediator.Send(new GetAllMaqvImpactoRcmQuery()));
        }
    }
}
