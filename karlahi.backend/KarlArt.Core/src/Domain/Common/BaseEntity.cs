using System.ComponentModel.DataAnnotations.Schema;

namespace KarlArt.Core.Domain.Common;

public interface IBaseEntity
{
    Guid Id { get; set; }
}

public abstract class BaseEntity : IBaseEntity
{
    public Guid Id { get; set; } = default!;
}

public interface IExternalEntity<TId>
{
    TId ExternalId { get; set; }
}
