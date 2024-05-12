using ConferenceRoomBooking.Models;
using ConferenceRoomBooking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
[Route("api/[controller]")]
[ApiController]
public class ReservationHolderController : ControllerBase
{
    private readonly IReservationHolderService _reservationHolderService;
    public ReservationHolderController(IReservationHolderService reservationHolderService)
    {
        _reservationHolderService = reservationHolderService;
    }
    [HttpPost]
    public IActionResult CreateReservationHolder([FromBody] ReservationHolderModel model)
    {
        try
        {
            _reservationHolderService.AddReservationHolder(model.IdCardNumber, model.Name, model.Surname, model.Email, model.PhoneNumber, model.Notes, model.BookingId);
            return Ok("Reservation holder created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to create reservation holder: {ex.Message}");
        }
    }
    [HttpGet("{id}")]
    public IActionResult ViewReservationHolder(int id)
    {
        var reservationHolder = _reservationHolderService.GetReservationHolderById(id);
        if (reservationHolder == null)
        {
            return NotFound("Reservation holder not found");
        }
        return Ok(reservationHolder);
    }
    [HttpPut("{id}")]
    public IActionResult UpdateReservationHolder(int id, [FromBody] ReservationHolderModel model)
    {
        try
        {
            _reservationHolderService.UpdateReservationHolder(id, model.IdCardNumber, model.Name, model.Surname, model.Email, model.PhoneNumber, model.Notes, model.BookingId);
            return Ok("Reservation holder updated successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to update reservation holder: {ex.Message}");
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteReservationHolder(int id)
    {
        try
        {
            _reservationHolderService.DeleteReservationHolder(id);
            return Ok("Reservation holder deleted successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to delete reservation holder: {ex.Message}");
        }
    }
}
