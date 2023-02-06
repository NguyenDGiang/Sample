using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Dtos.Products
{
    public class UploadFileProductDto
    {
        public IFormFile File { get; set; }
        public Guid ProductId { get; set; }
    }
}
