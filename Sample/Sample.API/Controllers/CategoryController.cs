using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Services.Categories;
using Sample.Shared.Dtos.Categories;
using Sample.Shared.SeedWorks;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(_categoryService.GetAll());
        }
        [HttpPost()]
        public IActionResult Post(UpdateCategoryDto category)
        {
            return Ok(_categoryService.Create(category));
        }
        [HttpDelete()]
        public IActionResult Delete(int Id)
        {
            return Ok(_categoryService.Delete(Id));
        }
        [HttpGet("GetPaging")]
        public IActionResult Get([FromQuery]PagingParamesters paging)
        {
            return Ok(_categoryService.GetPaging(paging));
        }
    }
}
