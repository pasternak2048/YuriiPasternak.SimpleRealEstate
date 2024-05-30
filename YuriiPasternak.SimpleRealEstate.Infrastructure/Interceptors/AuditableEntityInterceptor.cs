using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Domain.Common;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Interceptors
{
    public class AuditableEntityInterceptor : SaveChangesInterceptor
    {
        private readonly ICurrentUserInitializer _currentUserInitializer;

        public AuditableEntityInterceptor(ICurrentUserInitializer currentUserInitializer)
        {
            _currentUserInitializer = currentUserInitializer;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = new())
        {
            foreach (var entry in eventData.Context.ChangeTracker.Entries<AuditableEntity>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedById = _currentUserInitializer.UserId.GetValueOrDefault();
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedById = _currentUserInitializer.UserId;
                        entry.Entity.ModifiedAt = DateTime.UtcNow;
                        break;
                }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
