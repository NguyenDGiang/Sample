using Sample.Core.Common.Interfaces;

namespace Sample.Core.Common
{
    public abstract class EntityBase<T> : IEntityBase<T>
    {
        public T Id { get; set; }
    }
}
