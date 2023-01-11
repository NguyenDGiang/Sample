using Sample.Shared.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Sample.Shared.Common
{
    public abstract class EntityBase<T> : IEntityBase<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
