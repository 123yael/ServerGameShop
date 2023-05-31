using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO.Repository;

namespace Project_GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IFunctionsBLL _functionsBLL;

        public ProductsController(IFunctionsBLL functionsBLL)
        {
            this._functionsBLL = functionsBLL;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(_functionsBLL.GetAllProducts());
        }

        [HttpGet("GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_functionsBLL.GetProductById(id));
        }

        [HttpGet("GetProductsByCategoryId/{id}")]
        public IActionResult GetProductsByCategoryId(int id)
        {
            return Ok(_functionsBLL.GetProductsByCategoryId(id));
        }

        [HttpPost("AddNewProduct")]
        public IActionResult AddNewProduct([FromBody] ProductsDTO p)
        {
            return Ok(_functionsBLL.AddNewProduct(p));
        }

        [HttpPut("UpdateProduct/{id}")]
        public IActionResult UpdateProducts(int id, [FromBody] ProductsDTO p)
        {
            return Ok(_functionsBLL.UpdateProduct(id, p));
        }

        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            return Ok(_functionsBLL.DeleteProduct(id));
        }
    }
}
