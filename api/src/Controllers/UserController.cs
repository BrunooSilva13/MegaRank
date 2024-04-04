using api.Models;
using api.Services;
using api.src.Services;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;
using System.Collections.Generic;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            _userService.CreateUser(user);
            return StatusCode(201, $"Created: User created successfully");
        }

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(string id, User user)
        {
            _userService.UpdateUser(user);
            return Ok(user);
        }

    }
}
