using Microsoft.AspNetCore.Http;
using Sample.Core.Entities;
using Sample.Shared.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Sample.Application.Services.UploadFiles
{
    public interface IUploadFileService
    {
        ApiResult<UploadFile> Insert(IFormFile file);
    }
}
