using Core.Interfaces;
using Forge.Helpers;
using Forge.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Forge.Controllers;

/// <summary>
/// EventController
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EventController(IEventService eventService, IWebHostEnvironment webHostEnvironment)
    : ControllerBase
{
    /// <summary>
    /// Get a Event by Guid
    /// /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpGet("{guid:Guid}", Name = "GetEventByGuid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetEventByGuid([FromRoute] Guid guid)
    {
        try
        {
            // Validate the Guid
            if (guid == Guid.Empty)
            {
                return ApiResponseHelper.BadRequest("Invalid Guid provided.");
            }

            // Get the status from the database
            var status = await eventService.GetEventByGuid(guid);
            // Return the status
            return ApiResponseHelper.Success(status);
        }
        catch (Exception ex)
        {
            // Return a problem response, in development mode, it will include the stack trace
            return ApiResponseHelper.Problem(ex, webHostEnvironment.IsDevelopment());
        }
    }
}
