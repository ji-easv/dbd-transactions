using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using online_store.Domain.Interfaces;
using online_store.Infrastructure.Contexts;

namespace online_store.Infrastructure.UnitOfWork;

public class UnitOfWork(ECommerceDbContext context) : IUnitOfWork, IDisposable
{
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel)
    {
        var transaction = await context.Database.BeginTransactionAsync(isolationLevel);
        return transaction;
    }

    public async Task CommitAsync()
    {
        await context.Database.CommitTransactionAsync();
    }

    public async Task RollbackAsync()
    {
        await context.Database.RollbackTransactionAsync();
    }

    public void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }
}   