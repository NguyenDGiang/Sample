using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Sample.Core.Entities;
using Sample.DataAccess.Repositories.UploadFiles;
using Sample.Shared.SeedWorks;
using Sample.Shared.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Services.UploadFiles
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IUploadFileRepository _uploadFileRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public UploadFileService(IUploadFileRepository uploadFileRepository, 
            IHostingEnvironment hostingEnvironment)
        {
            _uploadFileRepository = uploadFileRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public ApiResult<UploadFile> Insert(IFormFile file)
        {
            var fileType = Path.GetExtension(file.FileName);
            if (FileTypeSupport.Document.Contains(fileType))
            {
                InsertDocument(file);
            }
            return null;
        }
        private void InsertDocument(IFormFile file)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads\\"+file.Name);
            if (file.Length > 0 && file.Length < 10485760)
            {
                using (var stream = new FileStream(uploads, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
        }
    }
}
