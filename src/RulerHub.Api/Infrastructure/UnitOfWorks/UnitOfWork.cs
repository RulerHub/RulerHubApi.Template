using Microsoft.EntityFrameworkCore.Storage;

using RulerHub.Api.Domain.Interfaces;
using RulerHub.Api.Infrastructure.Data;
using RulerHub.Api.Infrastructure.Repositories;

namespace RulerHub.Api.Infrastructure.UnitOfWorks;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;
    private IDbContextTransaction? _transaction;

    public IProductRepository Products => new ProductRepository(_context);
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
