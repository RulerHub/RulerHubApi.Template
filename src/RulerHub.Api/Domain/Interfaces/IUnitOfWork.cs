namespace RulerHub.Api.Domain.Interfaces;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
    //ICategoryRepository Categories { get; }
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
