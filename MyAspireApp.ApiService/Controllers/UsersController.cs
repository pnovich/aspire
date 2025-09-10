using Microsoft.AspNetCore.Mvc;
using MyAspireApp.ApiService.Entities;
using MyAspireApp.ApiService.Models.Requests;
using MyAspireApp.ApiService.Services;

namespace MyAspireApp.ApiService.Controllers;

    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest user)
        {
            User created = _userService.CreateUser(user);
            return CreatedAtAction(nameof(CreateUser), new { id = created.Id }, created);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
