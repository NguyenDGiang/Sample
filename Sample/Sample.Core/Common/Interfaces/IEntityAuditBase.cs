namespace Sample.Core.Common.Interfaces
{
    public interface IEntityAuditBase<T> : IEntityBase<T>, IAuditable
    {
    }
}
