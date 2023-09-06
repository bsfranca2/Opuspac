using Microsoft.AspNetCore.Mvc;
using Opuspac.Api.Utilities;

namespace Opuspac.Api.Controllers;

[ApiController]
[Route("/info")]
public class InfoController : Controller
{
    [HttpGet]
    public IResult Get()
    {
        var headers = Request.Headers;
        var headersDictionary = headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString());
        return Results.Ok(new
        {
            Ip = Request.GetRemoteIpAddress(),
            Headers = headersDictionary,
        });
    }
}
