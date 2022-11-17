using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Services.Products;
using Sample.Shared.Dtos.Products;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost()]
        public IActionResult Post(CreateProductDto product)
        {
            return Ok(_productService.Create(product));
        }
    }
}
