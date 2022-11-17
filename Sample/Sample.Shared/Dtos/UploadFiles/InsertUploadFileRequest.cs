using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Dtos.UploadFiles
{
    public class InsertUploadFileRequest
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public string ProductId { get; set; }
    }
}
