using ConferenceRoomBooking.Models;
using ConferenceRoomBooking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class BookingController : Controller
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost]
    public IActionResult CreateBooking([FromBody] BookingModel model)
    {
        try
        {
            _bookingService.AddBooking(model.Code, model.NumberOfPeople, model.IsConfirmed, model.RoomId, model.StartDate, model.EndDate);
            return Ok("Booking created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to create booking: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public IActionResult ViewBooking(int id)
    {
        var booking = _bookingService.GetBookingById(id);
        if (booking == null)
        {
            return NotFound("Booking not found");
        }
        return Ok(booking);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBooking(int id, [FromBody] BookingModel model)
    {
        try
        {
            _bookingService.UpdateBooking(id, model.Code, model.NumberOfPeople, model.IsConfirmed, model.RoomId, model.StartDate, model.EndDate);
            return Ok("Booking updated successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to update booking: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBooking(int id)
    {
        try
        {
            _bookingService.DeleteBooking(id);
            return Ok("Booking deleted successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to delete booking: {ex.Message}");
        }
    }
}
