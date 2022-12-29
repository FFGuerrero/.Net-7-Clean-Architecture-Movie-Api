using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("")]
[ApiExplorerSettings(IgnoreApi = true)]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    public IActionResult RedirectToDefaultVersion()
    {
        return Redirect("/api");
    }
}