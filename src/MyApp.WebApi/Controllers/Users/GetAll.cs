using Microsoft.AspNetCore.Mvc;

namespace MyApp.WebApi.Controllers.Users;

[ApiController]
[Route("api/user/all")]
public class GetAll : Controller
{
    [HttpGet]
    public ActionResult Index()
    {
        return Ok();
    }
}
