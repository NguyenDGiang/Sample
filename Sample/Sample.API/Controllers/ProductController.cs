using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Exceptions;
using Sample.Application.Services.Products;
using Sample.Shared.Dtos.Products;
using Sample.Shared.SeedWorks;

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
        [HttpPost("ProductVariant")]
        public IActionResult Post(CreateProductMappingAttributeDto createProductMappingAttributeDto)
        {
            return Ok(_productService.CreateMappingAttribute(createProductMappingAttributeDto));
        }
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(_productService.GetAll());
        }
        [HttpGet("Paging")]
        public IActionResult GetPaging([FromQuery] PagingParamesters pagingParamesters)
        {
            return Ok(_productService.GetPaging(pagingParamesters));
        }
        [HttpPut("Update")]
        public IActionResult Update(UpdateProductDto productDto)
        {
            return Ok(_productService.Update(productDto));
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Guid Id)
        {
            return Ok(_productService.Delete(Id));
        }
        [HttpGet("GetById")]
        public IActionResult Get(Guid Id)
        {
            return Ok(_productService.Get(Id));
        }
    }
}
