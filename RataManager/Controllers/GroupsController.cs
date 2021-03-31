using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RataManager.Controllers
{
    [ApiController]
    [ApiVersion("1.1")]
    [Route("api/v{version:apiVersion}/groups")]
    public class GroupsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }
    }
}