namespace RulerHub.Api.Core.Entities.Abstracts;

public interface IEntity<TKey>
{
    public TKey Id { get; set; }
}
