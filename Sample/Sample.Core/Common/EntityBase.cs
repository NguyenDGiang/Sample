using Sample.Shared.Common.Interfaces;

namespace Sample.Shared.Common
{
    public abstract class EntityBase<T> : IEntityBase<T>
    {
        public T Id { get; set; }
    }
}
