using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO.Repository;

namespace Project_GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IFunctionsBLL _functionsBLL;

        public CartController(IFunctionsBLL functionsBLL)
        {
            this._functionsBLL = functionsBLL;
        }

        [HttpPost("CheckOrder")]
        public IActionResult CheckOrder([FromBody] List<ProductToClintDTO> list)
        {
            return Ok(_functionsBLL.CheckOrder(list));
        }

        [HttpPost("FinishOrder/{userId}")]
        public IActionResult FinishOrder(int userId, [FromBody] List<ProductToClintDTO> list)
        {
            try
            {
                return Ok(_functionsBLL.FinishOrder(userId, list));
            }
            catch
            {
                return Ok("not ok");
            }
        }
    }
}
