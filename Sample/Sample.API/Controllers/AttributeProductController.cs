using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Services.AttributeProducts;
using Sample.Shared.Dtos.AttributeProducts;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeProductController : ControllerBase
    {
        private readonly IAttributeProductService _attributeProductService;
        public AttributeProductController(IAttributeProductService attributeProductService)
        {
            _attributeProductService = attributeProductService;
        }
        [HttpPost]
        public IActionResult Post(CreateAttributeProductDto createAttributeProductDto)
        {
            return Ok(_attributeProductService.Create(createAttributeProductDto));
        }
    }
}
