using Microsoft.AspNetCore.Mvc;
using MyAspireApp.ApiService.Entities;
using MyAspireApp.ApiService.Models.Requests;
using MyAspireApp.ApiService.Services;

namespace MyAspireApp.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var response = await _userService.GetAllUsers();
        if (!response.Success)
            return NotFound(response.Message);

        return Ok(response.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var response = await _userService.GetUserById(id);
        if (!response.Success)
            return NotFound(response.Message);

        return Ok(response.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            AddressCountry = request.AddressCountry,
            AddressRegion = request.AddressRegion,
            AddressState = request.AddressState,
            AddressCity = request.AddressCity,
            AddressStreet = request.AddressStreet,
            AddressStreet2 = request.AddressStreet2,
            AddressCode = request.AddressCode,
            PhoneNumber = request.PhoneNumber,
            Notes = request.Notes
        };

        var response = await _userService.CreateUser(user);
        if (!response.Success)
            return BadRequest(response.Message);

        return CreatedAtAction(nameof(GetUser), new { id = response.Data.Id }, response.Data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] CreateUserRequest request)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            AddressCountry = request.AddressCountry,
            AddressRegion = request.AddressRegion,
            AddressState = request.AddressState,
            AddressCity = request.AddressCity,
            AddressStreet = request.AddressStreet,
            AddressStreet2 = request.AddressStreet2,
            AddressCode = request.AddressCode,
            PhoneNumber = request.PhoneNumber,
            Notes = request.Notes
        };

        var response = await _userService.UpdateUser(id, user);
        if (!response.Success)
            return NotFound(response.Message);

        return Ok(response.Data);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var response = await _userService.DeleteUser(id);
        if (!response.Success)
            return NotFound(response.Message);

        return NoContent();
    }
}