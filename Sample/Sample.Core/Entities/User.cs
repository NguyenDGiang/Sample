using Sample.Shared.Common;

namespace Sample.Shared.Entities
{
    public class User : EntityAuditBase<Guid>
    {
        public string? DisplayName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public byte[] StoreSalt { get; set; }
    }
}
