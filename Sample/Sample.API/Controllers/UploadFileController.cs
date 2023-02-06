using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Services.UploadFiles;
using Sample.Shared.Dtos.Products;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IUploadFileService _uploadFileService;

        public UploadFileController(IUploadFileService uploadFileService)
        {
            _uploadFileService = uploadFileService;
        }

        [HttpPost()]
        public IActionResult Post([FromForm]UploadFileProductDto uploadFileProductDto)
        {
            return Ok(_uploadFileService.Insert(uploadFileProductDto));
        }
    }
}
