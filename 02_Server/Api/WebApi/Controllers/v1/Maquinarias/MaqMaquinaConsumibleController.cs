using Aplicacion.Features.Maquinarias.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Maquinarias
{
    [ApiVersion("1.0")]
    [Authorize]
    public class MaqMaquinaConsumibleController : BaseApiController
    {
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetConsumible(int id)
        {
            return Ok(await Mediator.Send(new GetAllMaqMaquinaConsumibleQuery
            {
                parametroComsumible = id
            }));
        }
    }
}
