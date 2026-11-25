using BoardGameHub.Core.Contracts;
using BoardGameHub.Core.DTOs.Shop.Request;
using BoardGameHub.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameHub.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsApiController(IShopServices shopServices) : ControllerBase
    {
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchRequest request)
        {
            var result = await shopServices.SearchAsync(request);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
