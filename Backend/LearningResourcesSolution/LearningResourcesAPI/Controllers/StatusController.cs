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
        var contact = _systemTime.GetCurrent().Hour < 16 ? "bob@aol.com" : "555-555-5555";
        var res = new GetStatusResponse
        {
            Message = "All's Good",
            Contact = contact
        };

        return Ok(res);
    }
}

public class GetStatusResponse
{
    public string Message { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
}



