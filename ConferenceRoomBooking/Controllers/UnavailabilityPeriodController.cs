using ConferenceRoomBooking.Models;
using ConferenceRoomBooking.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class UnavailabilityPeriodController : ControllerBase
{
    private readonly IUnavailabilityPeriodService _unavailabilityPeriodService;

    public UnavailabilityPeriodController(IUnavailabilityPeriodService unavailabilityPeriodService)
    {
        _unavailabilityPeriodService = unavailabilityPeriodService;
    }

    [HttpPost]
    public IActionResult CreateUnavailabilityPeriod([FromBody] UnavailabilityPeriodModel model)
    {
        try
        {
            _unavailabilityPeriodService.AddUnavailabilityPeriod(model.StartDate, model.EndDate);
            return Ok("Unavailability period created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to create unavailability period: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public IActionResult ViewUnavailabilityPeriod(int id)
    {
        var unavailabilityPeriod = _unavailabilityPeriodService.GetUnavailabilityPeriodById(id);
        if (unavailabilityPeriod == null)
        {
            return NotFound("Unavailability period not found");
        }
        return Ok(unavailabilityPeriod);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUnavailabilityPeriod(int id, [FromBody] UnavailabilityPeriodModel model)
    {
        try
        {
            _unavailabilityPeriodService.UpdateUnavailabilityPeriod(id, model.StartDate, model.EndDate);
            return Ok("Unavailability period updated successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to update unavailability period: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUnavailabilityPeriod(int id)
    {
        try
        {
            _unavailabilityPeriodService.DeleteUnavailabilityPeriod(id);
            return Ok("Unavailability period deleted successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to delete unavailability period: {ex.Message}");
        }
    }
}
