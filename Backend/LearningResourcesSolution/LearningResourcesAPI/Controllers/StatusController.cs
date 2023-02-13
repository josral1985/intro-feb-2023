using LearningResourcesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningResourcesAPI.Controllers;
public class StatusController : ControllerBase
{
    private ISystemTime _systemTime;

    public StatusController(ISystemTime systemTime)
    {
        _systemTime = systemTime;
    }

    //GET /status
    [HttpGet("/status")]
    public ActionResult GetTheStatus()
    {
        var contact = _systemTime.GetCurrent().Hour < 16 ? "555-555-5555" : "bob@aol.com";
        var res = new GetStatusResponse("All's Good", contact);

        return Ok(res);
    }
}

public record GetStatusResponse(string Message, string Contact);



