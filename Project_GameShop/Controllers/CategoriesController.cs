using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DTO.Repository;

namespace Project_GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IFunctionsBLL _functionsBLL;

        public CategoriesController(IFunctionsBLL functionsBLL)
        {
            this._functionsBLL = functionsBLL;
        }

        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            return Ok(_functionsBLL.GetAllCategories());
        }

        [HttpPost("AddNewCategory")]
        public IActionResult AddNewCategory([FromBody] CategoriesDTO c)
        {
            return Ok(_functionsBLL.AddNewCategory(c));
        }

        [HttpPut("UpdateCategory/{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoriesDTO c)
        {
            return Ok(_functionsBLL.UpdateCategory(id, c));
        }

        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            return Ok(_functionsBLL.DeleteCategory(id));
        }

    }
}
