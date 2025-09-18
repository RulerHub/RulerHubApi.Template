namespace RulerHub.Domain.Entities.Abstracts;

public interface IEntity<TKey>
{
    public TKey Id { get; set; }
}
