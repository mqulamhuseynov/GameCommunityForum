using GamingForumApplication.IRepos.Persistence;
using GamingForumInfrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GamingForumInfrastructure.Implementations
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken ct = default)
            => context.SaveChangesAsync(ct);

        public async Task ExecuteInTransactionAsync(
            Func<CancellationToken, Task>
            operation,
            CancellationToken ct = default)
        {
            await ExecuteInTransactionAsync<object?>(async ct =>
            {
                await operation(ct);
                return null;
            }, ct);
        }

        public async Task<TResult> ExecuteInTransactionAsync<TResult>(
            Func<CancellationToken,
            Task<TResult>> operation,
            CancellationToken ct = default)
        {
            var strategy = context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async ct =>
            {
                await using var transaction = await context.Database
                                                                .BeginTransactionAsync(ct);
                
                var result = await operation(ct);

                await transaction.CommitAsync(ct);
                return result;
            }, ct);
        }
    }
}
