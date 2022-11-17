using Sample.Shared.Common;

namespace Sample.Core.Entities
{
    public class UploadFile : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public Product? Product { get; set; }
    }
}
