using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.WebApi.Controllers.Users;

[ApiController]
[Authorize]
[Route("api/user/all")]
public class GetAll : Controller
{
    [HttpGet]
    public ActionResult Index()
    {
        return Ok();
    }
}
