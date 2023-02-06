using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Sample.Core.Entities;
using Sample.DataAccess.Repositories.Products;
using Sample.DataAccess.Repositories.UploadFiles;
using Sample.Shared.Dtos.Products;
using Sample.Shared.Dtos.UploadFiles;
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
        private readonly IProductRepository _productRepository;
        private readonly IUploadFileRepository _uploadFileRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;
        public UploadFileService(
            IUploadFileRepository uploadFileRepository, 
            IHostingEnvironment hostingEnvironment,
            IMapper mapper,
            IProductRepository ProductRepository)
        {
            _uploadFileRepository = uploadFileRepository;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
            _productRepository = ProductRepository; 
        }

        public ApiResult<UploadFile> Insert(UploadFileProductDto uploadFileProductDto)
        {
            try
            {
                _uploadFileRepository.BeginTransactionAsync();
                var fileType = Path.GetExtension(uploadFileProductDto.File.FileName);
                var product = _productRepository.FindById(uploadFileProductDto.ProductId);
                if (product == null)
                {
                    return new ApiErrorResult<UploadFile>(false, 400, "Không tồn tại");
                }
                UploadFile insertUploadFileRequest = new UploadFile()
                {
                    Name = uploadFileProductDto.File.FileName,
                    Type = fileType,
                    Path = uploadFileProductDto.File.Name,
                    Product = product
                };
                if (FileTypeSupport.Image.Contains(fileType))
                {
                    InsertImage(uploadFileProductDto.File);
                }
                _uploadFileRepository.Add(insertUploadFileRequest);
                _uploadFileRepository.EndTransactionAsync();
                return new ApiSuccessResult<UploadFile>(true, "Thêm Thành Công", 200, insertUploadFileRequest);
            }
            catch (Exception ex)
            {
                _uploadFileRepository.RollbackTransactionAsync();
                return new ApiErrorResult<UploadFile>(false, 500, "Lỗi Khi Xóa");
            }
            
        }
        private void InsertImage(IFormFile file)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads\\"+file.FileName);
            if (file.Length > 0 && file.Length < 10485760)
            {
                using (var stream = new FileStream(uploads, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            //_uploadFileRepository.
        }
    }
}
