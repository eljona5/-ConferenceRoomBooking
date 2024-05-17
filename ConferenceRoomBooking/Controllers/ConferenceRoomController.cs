using ConferenceRoomBooking.Models;
using ConferenceRoomBooking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class ConferenceRoomController : Controller
{
    private readonly IConferenceRoomService _conferenceRoomService;

    public ConferenceRoomController(IConferenceRoomService conferenceRoomService)
    {
        _conferenceRoomService = conferenceRoomService;
    }

    [HttpPost]
    public IActionResult AddConferenceRoom([FromBody] ConferenceRoomModel model)
    {
        try
        {
            _conferenceRoomService.AddConferenceRoom(model.Code, model.MaxCapacity);
            return Ok("Conference room added successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to add conference room: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetConferenceRoomById(int id)
    {
        var conferenceRoom = _conferenceRoomService.GetConferenceRoomById(id);
        if (conferenceRoom == null)
        {
            return NotFound("Conference room not found");
        }
        return Ok(conferenceRoom);
    }

    [HttpGet]
    public IActionResult GetAllConferenceRooms()
    {
        var conferenceRooms = _conferenceRoomService.GetAllConferenceRooms();
        return Ok(conferenceRooms);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateConferenceRoom(int id, [FromBody] ConferenceRoomModel model)
    {
        try
        {
            _conferenceRoomService.UpdateConferenceRoom(id, model.Code, model.MaxCapacity);
            return Ok("Conference room updated successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to update conference room: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteConferenceRoom(int id)
    {
        try
        {
            _conferenceRoomService.DeleteConferenceRoom(id);
            return Ok("Conference room deleted successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to delete conference room: {ex.Message}");
        }
    }
}