using ConferenceRoomBooking.Models;
using ConferenceRoomBooking.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserModel model)
    {
        try
        {
            _userService.AddUser(model.Name, model.Surname, model.Email);
            return Ok("User created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to create user: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public IActionResult ViewUser(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound("User not found");
        }
        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] UserModel model)
    {
        try
        {
            _userService.UpdateUser(id, model.Name, model.Surname, model.Email);
            return Ok("User updated successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to update user: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        try
        {
            _userService.DeleteUser(id);
            return Ok("User deleted successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to delete user: {ex.Message}");
        }
    }
}
