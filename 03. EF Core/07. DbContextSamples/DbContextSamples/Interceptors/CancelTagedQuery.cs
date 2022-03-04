using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContextSamples.Interceptors;
public class CancelTagedQuery : DbCommandInterceptor
{
    public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
    {
        var query = command.CommandText;
        Console.WriteLine(query);

        return base.ReaderExecuting(command, eventData, result);
    }
}
public class MyTransactionInterceptor : IDbTransactionInterceptor
{
    public void CreatedSavepoint(DbTransaction transaction, TransactionEventData eventData)
    {
        throw new NotImplementedException();
    }

    public Task CreatedSavepointAsync(DbTransaction transaction, TransactionEventData eventData, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public InterceptionResult CreatingSavepoint(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result)
    {
        throw new NotImplementedException();
    }

    public ValueTask<InterceptionResult> CreatingSavepointAsync(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void ReleasedSavepoint(DbTransaction transaction, TransactionEventData eventData)
    {
        throw new NotImplementedException();
    }

    public Task ReleasedSavepointAsync(DbTransaction transaction, TransactionEventData eventData, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public InterceptionResult ReleasingSavepoint(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result)
    {
        throw new NotImplementedException();
    }

    public ValueTask<InterceptionResult> ReleasingSavepointAsync(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void RolledBackToSavepoint(DbTransaction transaction, TransactionEventData eventData)
    {
        throw new NotImplementedException();
    }

    public Task RolledBackToSavepointAsync(DbTransaction transaction, TransactionEventData eventData, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public InterceptionResult RollingBackToSavepoint(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result)
    {
        throw new NotImplementedException();
    }

    public ValueTask<InterceptionResult> RollingBackToSavepointAsync(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void TransactionCommitted(DbTransaction transaction, TransactionEndEventData eventData)
    {
        throw new NotImplementedException();
    }

    public Task TransactionCommittedAsync(DbTransaction transaction, TransactionEndEventData eventData, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public InterceptionResult TransactionCommitting(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result)
    {
        throw new NotImplementedException();
    }

    public ValueTask<InterceptionResult> TransactionCommittingAsync(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void TransactionFailed(DbTransaction transaction, TransactionErrorEventData eventData)
    {
        throw new NotImplementedException();
    }

    public Task TransactionFailedAsync(DbTransaction transaction, TransactionErrorEventData eventData, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void TransactionRolledBack(DbTransaction transaction, TransactionEndEventData eventData)
    {
        throw new NotImplementedException();
    }

    public Task TransactionRolledBackAsync(DbTransaction transaction, TransactionEndEventData eventData, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public InterceptionResult TransactionRollingBack(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result)
    {
        throw new NotImplementedException();
    }

    public ValueTask<InterceptionResult> TransactionRollingBackAsync(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public DbTransaction TransactionStarted(DbConnection connection, TransactionEndEventData eventData, DbTransaction result)
    {
        throw new NotImplementedException();
    }

    public ValueTask<DbTransaction> TransactionStartedAsync(DbConnection connection, TransactionEndEventData eventData, DbTransaction result, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public InterceptionResult<DbTransaction> TransactionStarting(DbConnection connection, TransactionStartingEventData eventData, InterceptionResult<DbTransaction> result)
    {
        throw new NotImplementedException();
    }

    public ValueTask<InterceptionResult<DbTransaction>> TransactionStartingAsync(DbConnection connection, TransactionStartingEventData eventData, InterceptionResult<DbTransaction> result, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public DbTransaction TransactionUsed(DbConnection connection, TransactionEventData eventData, DbTransaction result)
    {
        throw new NotImplementedException();
    }

    public ValueTask<DbTransaction> TransactionUsedAsync(DbConnection connection, TransactionEventData eventData, DbTransaction result, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

public class MyConnectionInterceptor : IDbConnectionInterceptor
{
    public void ConnectionClosed(DbConnection connection, ConnectionEndEventData eventData)
    {
        throw new NotImplementedException();
    }

    public Task ConnectionClosedAsync(DbConnection connection, ConnectionEndEventData eventData)
    {
        throw new NotImplementedException();
    }

    public InterceptionResult ConnectionClosing(DbConnection connection, ConnectionEventData eventData, InterceptionResult result)
    {
        throw new NotImplementedException();
    }

    public ValueTask<InterceptionResult> ConnectionClosingAsync(DbConnection connection, ConnectionEventData eventData, InterceptionResult result)
    {
        throw new NotImplementedException();
    }

    public void ConnectionFailed(DbConnection connection, ConnectionErrorEventData eventData)
    {
        throw new NotImplementedException();
    }

    public Task ConnectionFailedAsync(DbConnection connection, ConnectionErrorEventData eventData, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void ConnectionOpened(DbConnection connection, ConnectionEndEventData eventData)
    {
        throw new NotImplementedException();
    }

    public Task ConnectionOpenedAsync(DbConnection connection, ConnectionEndEventData eventData, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public InterceptionResult ConnectionOpening(DbConnection connection, ConnectionEventData eventData, InterceptionResult result)
    {
        throw new NotImplementedException();
    }

    public ValueTask<InterceptionResult> ConnectionOpeningAsync(DbConnection connection, ConnectionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
public class AddAuditDataInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var changeTRacker = eventData.Context.ChangeTracker;

        var added = changeTRacker.Entries<IAuditable>().Where(c => c.State == EntityState.Added).ToList();

        foreach (var item in added)
        {
            item.Property(c => c.InsertDate).CurrentValue = DateTime.Now;
        }
        var modified = changeTRacker.Entries<IAuditable>().Where(c => c.State == EntityState.Modified).ToList();

        foreach (var item in modified)
        {
            item.Property(c => c.UpdateDate).CurrentValue = DateTime.Now;
        }

        return base.SavingChanges(eventData, result);
    }
}
