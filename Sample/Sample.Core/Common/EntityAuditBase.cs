using Sample.Shared.Common.Interfaces;

namespace Sample.Shared.Common
{
    public abstract class EntityAuditBase<T> : EntityBase<T>, IAuditable
    {
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? LastModifiedDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
