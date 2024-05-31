using APBD_c05.Models;
using APBD_c05.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_c05.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    private readonly ITripsService _tripsService;

    public TripsController(ITripsService tripsService)
    {
        _tripsService = tripsService;
    }

    [HttpGet]
    public IActionResult GetTrips()
    {
        var trips = _tripsService.GetTrips();
        return Ok(trips);
    }
}