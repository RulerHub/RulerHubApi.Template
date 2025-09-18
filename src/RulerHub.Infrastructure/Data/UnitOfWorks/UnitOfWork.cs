using Microsoft.EntityFrameworkCore.Storage;

using RulerHub.Domain.Interfaces.Abstracts;
using RulerHub.Domain.Interfaces.Stores;
using RulerHub.Infrastructure.Repositories;

namespace RulerHub.Infrastructure.Data.UnitOfWorks;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;
    private IDbContextTransaction? _transaction;

    public IProductRepository Products => new ProductRepository(_context);
    public ICategoryRepository Categories => new CategoryRepository(_context);
    // el mismo patrón para otras entidades...

    public async Task BeginTransactionAsync()
    {
        _transaction ??= await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task<int> SaveChangesAsync()
    => await _context.SaveChangesAsync();
}
