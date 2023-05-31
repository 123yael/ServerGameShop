using BLL;
using DTO.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IFunctionsBLL _functionsBLL;

        public UsersController(IFunctionsBLL functionsBLL)
        {
            this._functionsBLL = functionsBLL;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_functionsBLL.GetAllUsers());
        }

        [HttpPost("AddNewUser")]
        public IActionResult AddNewUser([FromBody] UsersDTO u)
        {
            return Ok(_functionsBLL.AddNewUser(u));
        }

        [HttpPut("UpdateUser/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UsersDTO u)
        {
            return Ok(_functionsBLL.UpdateUser(id, u));
        }

        [HttpGet("findUserByEmailAndPassword/{email}/{pass}")]
        public IActionResult findUserByEmailAndPassword(string email, string pass)
        {
            return Ok(_functionsBLL.findUserByEmailAndPassword(email, pass));
        }

        [HttpGet("isManager/{email}/{pass}")]
        public IActionResult isManager(string email, string pass)
        {
            return Ok(_functionsBLL.isManager(email, pass));
        }
    }
}
