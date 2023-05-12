using Microsoft.AspNetCore.Mvc;

namespace EasyMenu.WebAPI.Controllers;

[Route("client-api/[controller]")]
[ApiController]
public class MenuController : ControllerBase
{
    [HttpGet("{name}")]
    public async Task<IActionResult> GetMenu(string name)
    {
        return Ok();
    }
}