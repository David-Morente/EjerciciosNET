using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Model;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        static List<User> users = new List<User>();

        [HttpGet]
        [Route ("Users")]
        public IEnumerable<User> Get()
        {
            return users;
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser([FromBody] User user)
        {
            users.Add(user);
            return Ok("User created successfully.");
        }
    }
}
