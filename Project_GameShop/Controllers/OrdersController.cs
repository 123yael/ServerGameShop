using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IFunctionsBLL _functionsBLL;

        public OrdersController(IFunctionsBLL functionsBLL)
        {
            this._functionsBLL = functionsBLL;
        }

        [HttpGet("GetAllOrdersByUserId/{userId}")]
        public IActionResult GetAllOrdersByUserId(int userId)
        {
            return Ok(_functionsBLL.GetAllOrdersByUserId(userId));
        }
    }
}
