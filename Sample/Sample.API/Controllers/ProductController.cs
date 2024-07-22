using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Exceptions;
using Sample.Application.Services.Categories;
using Sample.Application.Services.Products;
using Sample.Shared.Dtos.AttributeProducts;
using Sample.Shared.Dtos.Products;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBackgroundTaskQueue _taskQueue;
        public ProductController(IProductService productService,
            IBackgroundTaskQueue taskQueue)
        {
            _productService = productService;
            _taskQueue = taskQueue;
        }
        [HttpPost()]
        public IActionResult Post(CreateProductDto product)
        {
            var pr = _productService.Create(product);
            _taskQueue.QueueBackgroundWorkItem(async s => await BuildWorkItemAsync(product));
            return Ok(pr);
        }
        private async Task BuildWorkItemAsync(CreateProductDto product)
        {
            
           _productService.Create(product);
        }
<<<<<<< HEAD
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
        [HttpGet("GetHomeProductCategory")]
        public IActionResult GetHomeProductCategory()
        {
            return Ok(_productService.GetHomeProductCategory());
        }
=======
>>>>>>> parent of acb1289 (update)
    }
}
